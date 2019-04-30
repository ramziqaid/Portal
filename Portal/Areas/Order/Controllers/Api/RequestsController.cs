using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using EfCoreGenericRepository.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Portal.Areas.Order.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Requests")]
    public class RequestsController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<ESS_GetOrder> requests = null;
            HttpResponseMessage result = GlobalVaribales.WebApiClient.GetAsync("Requests/GetRequestForManager/" + 1.ToString()).Result; 

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IEnumerable<ESS_GetOrder>>();
                readTask.Wait();

                requests = readTask.Result;
            }
            else //web api sent error response 
            {
                requests = Enumerable.Empty<ESS_GetOrder>();
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }

            //  return View("Index", requests);
            return Json(new { data = requests });


        }
    }
}