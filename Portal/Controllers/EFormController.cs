using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using EfCoreGenericRepository.Interfaces;
using EfCoreGenericRepository.Models;
using Microsoft.AspNetCore.Mvc;
 
using Portal.ViewModel;

namespace Portal.Controllers
{
    public class EFormController : Controller
    {
        private readonly IRequestTypeRepository _requestRepository;

        public EFormController(IRequestTypeRepository requestRepository )
        {
            _requestRepository = requestRepository;
        }

        public IActionResult List(int? TypeID)
        {
            IEnumerable<RequestType> requestsType;

            
            HttpResponseMessage result = GlobalVaribales.WebApiClient.GetAsync("EForm/" + TypeID.ToString()).Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IEnumerable<RequestType>>();
                readTask.Wait();

                requestsType =  readTask.Result;
            }
            else //web api sent error response 
            {

                requestsType = Enumerable.Empty<RequestType>();

                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
            RequestListViewModel requestListViewModel = new RequestListViewModel
            {
                RequestsType = requestsType,
                TitleCategory = ""
            };
            return View(requestListViewModel);
        }

    }
}