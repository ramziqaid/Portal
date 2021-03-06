﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using EfCoreGenericRepository;
using EfCoreGenericRepository.Interfaces;
using EfCoreGenericRepository.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Portal.Controllers;
using Portal.Data;
using Portal.ViewModel;
using Microsoft.AspNetCore.Identity;
using Portal.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using static EfCoreGenericRepository.EnumsType;

namespace Portal.Areas.Order.Controllers
{
    [Area("Order")]
    //[Authorize(Roles = "User")]
    [Authorize(Roles = "Admin,User")]
    public class AmendmentsController : BaseController
    {

        private readonly AmendmentReasonController amendmentReasonController = new AmendmentReasonController();
        private readonly EmployeeController employeeController = new EmployeeController();
        private ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RequestsController _requestsController;

        public AmendmentsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            _requestsController = new RequestsController(_context, userManager);
        }

        // GET: Order/Amendments
        public async Task<IActionResult> Index()
        { 
            IEnumerable<Request> amendments = await _requestsController.IndexByType((int)EnumsType.RequestTypeId.Amendment);
            return View(amendments);

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

        // GET: Order/Amendments/Create
        public IActionResult Create()
        {
            IEnumerable<AmendmentReason> amendmentReason = amendmentReasonController.Get();
            ViewBag.AmendmentReasonId = new SelectList(amendmentReason, "ID", "AmendReasonEn");
            ViewBag.employeeInfoViews = employeeController.Get();
            IEnumerable<EmployeeInfoView> employeeInfoViews = employeeController.Get();
            ViewBag.Date = DateTime.Now.ToString("dd/MM/yyyy");

            Request request = new Request();
            request.RequestTypeID = (int)EnumsType.RequestTypeId.Amendment;
            request.StatusID = (int)EnumsType.RequestStatus.NewRequest;
            request.CreatedBy = _userManager.GetUserId(HttpContext.User);//User.Identity.Name; 
            
            // request.CreatedDate = DateHelp.GetDateStr(DateTime.Now);
        
            var requestView = new RequestViewModel
            {
                Request = request,
                employeeInfos = employeeInfoViews
            };
            return View(requestView);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RequestViewModel requestModel)
        {
            if (ModelState.IsValid)
            {
                if (requestModel.file != null)
                {
                    requestModel.Request.FileName = await _requestsController.UploadFile(requestModel.file);
                }
                ApplicationUser user = _userManager.FindByNameAsync(User.Identity.Name).Result;
                _requestsController.AddStage(requestModel.Request, user.EmployeeID, 1, "Submit", null);
                var postTask = GlobalVaribales.WebApiClient.PostAsJsonAsync("Requests", requestModel.Request);
                postTask.Wait();
                 

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    Alert("This is success message", NotificationType.success);
                      return RedirectToAction(nameof(Index));
                }
                 
            }

            IEnumerable<AmendmentReason> amendmentReason = amendmentReasonController.Get();
            ViewBag.AmendmentReasonId = new SelectList(amendmentReason, "ID", "AmendReasonEn");
            requestModel.employeeInfos = employeeController.Get();
         
            return View(requestModel);
        }

     
        public async Task<IActionResult> Edit(int? id)
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
            if (request == null)
            {
                return NotFound();
            }
            IEnumerable<AmendmentReason> amendmentReason = amendmentReasonController.Get();
            ViewBag.AmendmentReasonId = new SelectList(amendmentReason, "ID", "AmendReasonEn");
            IEnumerable<EmployeeInfoView> employeeInfoViews = employeeController.Get();

            var requestView = new RequestViewModel
            {
                Request = request,
                employeeInfos = employeeInfoViews
            };
            return View(requestView);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RequestViewModel requestView)
        {
            if (ModelState.IsValid)
            {
                if (requestView.file != null)
                {
                    requestView.Request.FileName = await _requestsController.UploadFile(requestView.file);
                }

                var postTask = GlobalVaribales.WebApiClient.PutAsJsonAsync("Requests", requestView.Request);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    Alert("This is success message", NotificationType.success);
                    return RedirectToAction("Index");
                }

                return RedirectToAction(nameof(Index));
            }
            return View(requestView);
        }

        //// GET: Order/Amendments/Delete/5
        public async Task<IActionResult> Delete(int? id)
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
        [HttpDelete, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
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
            Alert("This is Delete message", NotificationType.info);
            return RedirectToAction(nameof(Index));
        }

        //private bool AmendmentExists(int id)
        //{
        //    return _context.Amendment.Any(e => e.ID == id);
        //}
    }
}
