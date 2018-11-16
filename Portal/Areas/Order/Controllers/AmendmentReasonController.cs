using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using EfCoreGenericRepository.Models;
using Microsoft.AspNetCore.Mvc;

namespace Portal.Areas.Order.Controllers
{
    [Area("Order")]
    public class AmendmentReasonController : Controller
    {
        public AmendmentReasonController()
        {

        }
        public IEnumerable<AmendmentReason> Get()
        {
            HttpResponseMessage result = GlobalVaribales.WebApiClient.GetAsync("AmendmentReasons").Result;
            IEnumerable<AmendmentReason> amendmentReason = null;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IEnumerable<AmendmentReason>>();
                readTask.Wait();

                amendmentReason = readTask.Result;
                
            }
            return amendmentReason;
        }
    }
}