using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EfCoreGenericRepository;
using EfCoreGenericRepository.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
 

namespace PortalAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/EmployeeInfoViews")]
    public class EmployeeInfoViewsController : Controller
    {
        private readonly PlutoContext _context;

        public EmployeeInfoViewsController(PlutoContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeInfoViews
        [HttpGet]
        public IEnumerable<EmployeeInfoView> GetEmployeeInfoView()
        {
            return _context.EmployeeInfoView;
        }

        // GET: api/EmployeeInfoViews/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeInfoView([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employeeInfoView = await _context.EmployeeInfoView.SingleOrDefaultAsync(m => m.EmployeeID == id);

            if (employeeInfoView == null)
            {
                return NotFound();
            }

            return Ok(employeeInfoView);
        }

        // PUT: api/EmployeeInfoViews/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeInfoView([FromRoute] long id, [FromBody] EmployeeInfoView employeeInfoView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employeeInfoView.EmployeeID)
            {
                return BadRequest();
            }

            _context.Entry(employeeInfoView).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeInfoViewExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/EmployeeInfoViews
        [HttpPost]
        public async Task<IActionResult> PostEmployeeInfoView([FromBody] EmployeeInfoView employeeInfoView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EmployeeInfoView.Add(employeeInfoView);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeInfoView", new { id = employeeInfoView.EmployeeID }, employeeInfoView);
        }

        // DELETE: api/EmployeeInfoViews/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeInfoView([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employeeInfoView = await _context.EmployeeInfoView.SingleOrDefaultAsync(m => m.EmployeeID == id);
            if (employeeInfoView == null)
            {
                return NotFound();
            }

            _context.EmployeeInfoView.Remove(employeeInfoView);
            await _context.SaveChangesAsync();

            return Ok(employeeInfoView);
        }

        private bool EmployeeInfoViewExists(long id)
        {
            return _context.EmployeeInfoView.Any(e => e.EmployeeID == id);
        }
    }
}