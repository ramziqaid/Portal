using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EfCoreGenericRepository;
using EfCoreGenericRepository.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
 

namespace PortalAPI.Areas.Order.Controllers
{
    [Produces("application/json")]
    [Route("api/AmendmentReasons")]
    public class AmendmentReasonsController : Controller
    {
        private readonly PlutoContext _context;

        public AmendmentReasonsController(PlutoContext context)
        {
            _context = context;
        } 

        // GET: api/AmendmentReasons
        [HttpGet]
        public IEnumerable<AmendmentReason> GetAmendmentReason()
        {
            return _context.AmendmentReasons;
        }

        // GET: api/AmendmentReasons/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAmendmentReason([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            } 
            var amendmentReason = await _context.AmendmentReasons.SingleOrDefaultAsync(m => m.ID == id); 
            if (amendmentReason == null)
            {
                return NotFound();
            } 
            return Ok(amendmentReason);
        }

        // PUT: api/AmendmentReasons/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAmendmentReason([FromRoute] int id, [FromBody] AmendmentReason amendmentReason)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != amendmentReason.ID)
            {
                return BadRequest();
            }

            _context.Entry(amendmentReason).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AmendmentReasonExists(id))
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

        // POST: api/AmendmentReasons
        [HttpPost]
        public async Task<IActionResult> PostAmendmentReason([FromBody] AmendmentReason amendmentReason)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.AmendmentReasons.Add(amendmentReason);
            await _context.SaveChangesAsync();
           
            return CreatedAtAction("GetAmendmentReason", new { id = amendmentReason.ID }, amendmentReason);
        }

        // DELETE: api/AmendmentReasons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAmendmentReason([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var amendmentReason = await _context.AmendmentReasons.SingleOrDefaultAsync(m => m.ID == id);
            if (amendmentReason == null)
            {
                return NotFound();
               
            }
        
            _context.AmendmentReasons.Remove(amendmentReason);
            await _context.SaveChangesAsync();
            
            return Ok(amendmentReason);
           // return StatusCode(HttpStatusCode.NoContent);
        }

        private bool AmendmentReasonExists(int id)
        {
            return _context.AmendmentReasons.Any(e => e.ID == id);
        }
    }
}