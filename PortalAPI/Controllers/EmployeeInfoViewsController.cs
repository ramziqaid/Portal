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
             return Ok(employeeInfoView);
        }

        //GET: api/EmployeeInfoViews
        //[HttpGet]
        // public IEnumerable<EmployeeInfoView> GetEmployeeInfoView2()
        // {
        //     return unitOfWork.employeeInfoView.GetAll();
        //     //return _context.EmployeeInfoView;
        // }


        [Route("~/api/employeeInfoView3")]
        [HttpGet]
        public async Task<IEnumerable<EmployeeInfoView>> employeeInfoView3()
        {
            return await unitOfWork.employeeInfoView.GetAllAsyn();
        }

        //// GET: api/EmployeeInfoViews/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetEmployeeInfoView([FromRoute] long id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var employeeInfoView = await _context.EmployeeInfoView.SingleOrDefaultAsync(m => m.EmployeeID == id);

        //    if (employeeInfoView == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(employeeInfoView);
        //}

        //// PUT: api/EmployeeInfoViews/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutEmployeeInfoView([FromRoute] long id, [FromBody] EmployeeInfoView employeeInfoView)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != employeeInfoView.EmployeeID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(employeeInfoView).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!EmployeeInfoViewExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/EmployeeInfoViews
        //[HttpPost]
        //public async Task<IActionResult> PostEmployeeInfoView([FromBody] EmployeeInfoView employeeInfoView)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _context.EmployeeInfoView.Add(employeeInfoView);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetEmployeeInfoView", new { id = employeeInfoView.EmployeeID }, employeeInfoView);
        //}

        //// DELETE: api/EmployeeInfoViews/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteEmployeeInfoView([FromRoute] long id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var employeeInfoView = await _context.EmployeeInfoView.SingleOrDefaultAsync(m => m.EmployeeID == id);
        //    if (employeeInfoView == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.EmployeeInfoView.Remove(employeeInfoView);
        //    await _context.SaveChangesAsync();

        //    return Ok(employeeInfoView);
        //}

        //private bool EmployeeInfoViewExists(long id)
        //{
        //    return _context.EmployeeInfoView.Any(e => e.EmployeeID == id);
        //}
    }
}