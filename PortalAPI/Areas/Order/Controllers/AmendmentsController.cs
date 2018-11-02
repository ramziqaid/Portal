using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortalAPI.Areas.Order.Data.Interfaces;
using PortalAPI.Areas.Order.Data.Model;
using PortalAPI.Data;

namespace PortalAPI.Areas.Order.Controllers
{
    [Produces("application/json")]
    [Route("api/Amendments")]
    public class AmendmentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IRequestRepository _requestRepository;
        private readonly IAmendmentRepository _amendmentRepository;

        public AmendmentsController(ApplicationDbContext context, IRequestRepository requestRepository, IAmendmentRepository amendmentRepository)
        {
            _context = context;
            _requestRepository = requestRepository;
            _amendmentRepository = amendmentRepository;
        }

        // GET: api/Amendments
        [HttpGet]
        public IEnumerable<Amendment> GetAmendment()
        {
            return _context.Amendment;
        }

        // GET: api/Amendments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAmendment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var amendment = await _context.Amendment.SingleOrDefaultAsync(m => m.ID == id);

            if (amendment == null)
            {
                return NotFound();
            }

            return Ok(amendment);
        }

        // PUT: api/Amendments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAmendment([FromRoute] int id, [FromBody] Amendment amendment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != amendment.ID)
            {
                return BadRequest();
            }

            _context.Entry(amendment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AmendmentExists(id))
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

        // POST: api/Amendments
        [HttpPost]
        public async Task<IActionResult> PostAmendment([FromBody] Request request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Requests.Add(request);
            foreach(Amendment amendment in request.Amendments)
            {
                amendment.RequestID = request.ID; 
            }
            _context.Amendment.AddRange(request.Amendments);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAmendment", new { id = request.ID }, request);
        }

        // DELETE: api/Amendments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAmendment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var amendment = await _context.Amendment.SingleOrDefaultAsync(m => m.ID == id);
            if (amendment == null)
            {
                return NotFound();
            }

            _context.Amendment.Remove(amendment);
            await _context.SaveChangesAsync();

            return Ok(amendment);
        }

        private bool AmendmentExists(int id)
        {
            return _context.Amendment.Any(e => e.ID == id);
        }
    }
}