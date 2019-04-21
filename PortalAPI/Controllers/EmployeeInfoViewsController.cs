using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EfCoreGenericRepository;
using EfCoreGenericRepository.Interfaces;
using EfCoreGenericRepository.Models;
using EfCoreGenericRepository.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
 

namespace PortalAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/EmployeeInfoView")]
    public class EmployeeInfoViewsController : Controller
    {
        private UnitOfWork unitOfWork;
        private IEmployeeInfoViewRepository _EmployeeInfoViews;

        public EmployeeInfoViewsController(PlutoContext plutoContext, IEmployeeInfoViewRepository EmployeeInfoViews)
        { 
            unitOfWork = new UnitOfWork(plutoContext);
            _EmployeeInfoViews = EmployeeInfoViews;
        }
         
        [HttpGet]
        public async Task<IActionResult> GetEmployeeInfoView()
        {  
            IEnumerable<EmployeeInfoView> employeeInfoView;
            employeeInfoView =await unitOfWork.employeeInfoView.GetAllAsyn();
            if (employeeInfoView ==null)
            {
                return NotFound();
            }
             return Ok(employeeInfoView.Distinct());
        }

    }
}