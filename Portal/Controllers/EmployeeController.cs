using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using EfCoreGenericRepository.Models;
using Microsoft.AspNetCore.Mvc;
 
namespace Portal.Controllers
{
    public class EmployeeController : Controller
    {
        public  IEnumerable< EmployeeInfoView> Get()
        {
            IEnumerable<EmployeeInfoView> employeeInfoViews = null;
            HttpResponseMessage result = GlobalVaribales.WebApiClient.GetAsync("EmployeeInfoView").Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IEnumerable<EmployeeInfoView>>();
                readTask.Wait();

                employeeInfoViews = readTask.Result;
            }
            return employeeInfoViews;
        }

        public EmployeeInfoView Find(long EmployeeID)
        {
            IEnumerable<EmployeeInfoView> employeeInfoViews = null;
              HttpResponseMessage result = GlobalVaribales.WebApiClient.GetAsync("EmployeeInfoView/" + EmployeeID.ToString()).Result;

            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IEnumerable<EmployeeInfoView>>();
                readTask.Wait();

                employeeInfoViews = readTask.Result;
            }
            return employeeInfoViews.FirstOrDefault();
        }
    }
}