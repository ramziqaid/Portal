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

namespace Portal.Areas.Order.Controllers
{
    [Area("Order")]
    [Authorize(Roles = "Admin, User")]
 
    public class RequestsController : Controller
    {
        //private readonly PlutoContext _context;
        private ApplicationDbContext _context;

        public RequestsController(ApplicationDbContext context)
        {
            _context = context;
        } 

        public async Task<IActionResult> Index()
        {
            IEnumerable<Request> requests = null;
            HttpResponseMessage result = GlobalVaribales.WebApiClient.GetAsync("Requests").Result;

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
            return View(requests);

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
        //// GET: Order/Requests/Details/5
        //public async Task<IActionResult> Details(int? id)
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

        //// GET: Order/Requests/Create
        //public IActionResult Create()
        //{
        //    ViewData["RequestTypeID"] = new SelectList(_context.RequestTypes, "id", "id");
        //    return View();
        //}

        //// POST: Order/Requests/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ID,EmployeeID,RequestTypeID,StatusID,CreatedDate,CreatedBy,IsDelegate,IsDelegateApprove,DelegateFromID,DelegateToID")] Request request)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(request);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["RequestTypeID"] = new SelectList(_context.RequestTypes, "id", "id", request.RequestTypeID);
        //    return View(request);
        //}

        //// GET: Order/Requests/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var request = await _context.Requests.SingleOrDefaultAsync(m => m.ID == id);
        //    if (request == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["RequestTypeID"] = new SelectList(_context.RequestTypes, "id", "id", request.RequestTypeID);
        //    return View(request);
        //}

        //// POST: Order/Requests/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("ID,EmployeeID,RequestTypeID,StatusID,CreatedDate,CreatedBy,IsDelegate,IsDelegateApprove,DelegateFromID,DelegateToID")] Request request)
        //{
        //    if (id != request.ID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(request);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!RequestExists(request.ID))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["RequestTypeID"] = new SelectList(_context.RequestTypes, "id", "id", request.RequestTypeID);
        //    return View(request);
        //}


        // POST: Order/Amendments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id,string ControlName,string FileName)
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
            return RedirectToAction( nameof(Index), ControlName);
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
