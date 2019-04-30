using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EfCoreGenericRepository;
using EfCoreGenericRepository.Models;
using System.Net.Http;
using System.IO;
using Microsoft.AspNetCore.Http;
using Portal.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Portal.Models;

namespace Portal.Areas.Order.Controllers
{
    [Area("Order")]
    [Authorize(Roles = "Admin,User")]

    public class RequestsController : Controller
    {
        //private readonly PlutoContext _context;
        private ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public RequestsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            return View();

            //IEnumerable<Request> requests = null;
            //HttpResponseMessage result = GlobalVaribales.WebApiClient.GetAsync("Requests").Result;

            //if (result.IsSuccessStatusCode)
            //{
            //    var readTask = result.Content.ReadAsAsync<IEnumerable<Request>>();
            //    readTask.Wait();

            //    requests = readTask.Result;
            //}
            //else //web api sent error response 
            //{
            //    requests = Enumerable.Empty<Request>();
            //    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            //}
            //return View(requests);

        }

        //[ActionName("IndexByType")]
        public async Task<IEnumerable<Request>> IndexByType(int RequestTypeID)
        {
            IEnumerable<Request> requests = null;
            HttpResponseMessage result = GlobalVaribales.WebApiClient.GetAsync("Requests/GetRequestByType/" + RequestTypeID.ToString()).Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IEnumerable<Request>>();
                readTask.Wait();

                requests = readTask.Result;
            }
            else //web api sent error response 
            {
                requests = Enumerable.Empty<Request>();
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }

            return requests;

        }

        [HttpGet]
        public async Task<IActionResult> GetRequestForManager(long employeeID)
        {
            IEnumerable<Request> requests = null;
            HttpResponseMessage result = GlobalVaribales.WebApiClient.GetAsync("Requests/GetRequestForManager/" + employeeID.ToString()).Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IEnumerable<Request>>();
                readTask.Wait();

                requests = readTask.Result;
            }
            else //web api sent error response 
            {
                requests = Enumerable.Empty<Request>();
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }

            return View("Index", requests);
         
        }

        [HttpGet]
        public async Task<IActionResult> AddAction(int RequestID,int StageTypeID)
        {
             
            RequestStage requestStage = new RequestStage();
            requestStage.RequestID = RequestID;
            requestStage.StageTypeID = StageTypeID;
 
            return View(requestStage);
        }

        [HttpPost]
        public async Task<IActionResult> AddAction(Request requestStage)
        {
            ApplicationUser user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            requestStage.EmployeeID = user.EmployeeID;

            var postTask = GlobalVaribales.WebApiClient.PostAsJsonAsync("RequestStage", requestStage);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                TempData["Message"] = "تم الحفظ  !";
                return RedirectToAction("Index");
            }

            return RedirectToAction(nameof(Index));
        }


        // GET: Order/Amendments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Request request = null;
            HttpResponseMessage result = GlobalVaribales.WebApiClient.GetAsync("Requests/" + id.ToString()).Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Request>();
                readTask.Wait();

                request = readTask.Result;
            }

            return View(request);
        }

        // POST: Order/Amendments/Delete/5

        [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, string ControlName, string FileName)
        {
            if (id == null)
            {
                return NotFound();
            }

            HttpResponseMessage result = GlobalVaribales.WebApiClient.DeleteAsync("Requests/" + id.ToString()).Result;
            if (!result.IsSuccessStatusCode)
            {
                return BadRequest();
            }
            DeleteFile(FileName);
            return RedirectToAction(nameof(Index), ControlName);

            //return Json(new { success = true, message = "Delete success." });
        }

        //// GET: Order/Requests/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var request = await _context.Requests
        //        .Include(r => r.RequestType)
        //        .SingleOrDefaultAsync(m => m.ID == id);
        //    if (request == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(request);
        //}

        //// POST: Order/Requests/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var request = await _context.Requests.SingleOrDefaultAsync(m => m.ID == id);
        //    _context.Requests.Remove(request);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool RequestExists(int id)
        //{
        //    return _context.Requests.Any(e => e.ID == id);
        //}



        public void AddStage(Request request, long pEmployeeID, int pStageTypeID, string pActionName, string pNote)
        {
            RequestStage obj = new RequestStage();
            obj.StageTypeID = pStageTypeID;
            obj.EmployeeID = pEmployeeID;
            obj.ActionName = pActionName;
            obj.Justification = pNote;
            request.RequestStages = new List<RequestStage>();
            request.RequestStages.Add(obj);
        }

        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }


        public async Task<string> UploadFile(IFormFile file)
        {
            string uniqueFileName = null;
            if (file != null)
            {
                uniqueFileName = GetUniqueFileName(file.FileName);
                var filePath = Path.Combine(
                         Directory.GetCurrentDirectory(),
                         "wwwroot/uploads", uniqueFileName);

                if (!System.IO.File.Exists(filePath))
                {
                    await file.CopyToAsync(new FileStream(filePath, FileMode.Create));
                }

            }
            return uniqueFileName;

        }

        public async Task<IActionResult> DownloadFile(string filename)
        {

            if (filename == null)
                return Content("filename not present");
            // var uploads = Path.Combine(hostingEnvironment.WebRootPath, "uploads");

            var filePath = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/uploads", filename);
            if (!System.IO.File.Exists(filePath))
            {
                return Content("filename not present");
            }
            var memory = new MemoryStream();
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(filePath), Path.GetFileName(filePath));
        }

        public async Task DeleteFile(string filename)
        {
            if (filename == null) return;
            var filePath = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/uploads", filename);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
        }

        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }

    }
}
