using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EfCoreGenericRepository;
using EfCoreGenericRepository.Models;
using EfCoreGenericRepository.Repository;

namespace PortalAPI.Areas.Order.Controllers
{
    //[Produces("application/json")]
    //[Route("api/Requests")]
    //public class RequestsController : Controller
    //{
    //    private readonly UnitOfWork unitOfWork;

    //    public RequestsController(PlutoContext plutoContext)
    //    {

    //        unitOfWork = new UnitOfWork(plutoContext);
    //    }

    //    // GET: api/Requests
    //    [HttpGet]
    //    public async Task<IEnumerable<Request>> GetRequests()
    //    {
    //        return _context.Requests;
    //    }

    //    // GET: api/Requests/5
    //    [HttpGet("{id}")]
    //    public async Task<IActionResult> GetRequest([FromRoute] int id)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return BadRequest(ModelState);
    //        }

    //        var request = await _context.Requests.SingleOrDefaultAsync(m => m.ID == id);

    //        if (request == null)
    //        {
    //            return NotFound();
    //        }

    //        return Ok(request);
    //    }

    //    // PUT: api/Requests/5
    //    [HttpPut("{id}")]
    //    public async Task<IActionResult> PutRequest([FromRoute] int id, [FromBody] Request request)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return BadRequest(ModelState);
    //        }

    //        if (id != request.ID)
    //        {
    //            return BadRequest();
    //        }

    //        _context.Entry(request).State = EntityState.Modified;

    //        try
    //        {
    //            await _context.SaveChangesAsync();
    //        }
    //        catch (DbUpdateConcurrencyException)
    //        {
    //            if (!RequestExists(id))
    //            {
    //                return NotFound();
    //            }
    //            else
    //            {
    //                throw;
    //            }
    //        }

    //        return NoContent();
    //    }

    //    // POST: api/Requests
    //    [HttpPost]
    //    public async Task<IActionResult> PostRequest([FromBody] Request request)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return BadRequest(ModelState);
    //        }

    //        _context.Requests.Add(request);
    //        await _context.SaveChangesAsync();

    //        return CreatedAtAction("GetRequest", new { id = request.ID }, request);
    //    }

    //    // DELETE: api/Requests/5
    //    [HttpDelete("{id}")]
    //    public async Task<IActionResult> DeleteRequest([FromRoute] int id)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return BadRequest(ModelState);
    //        }

    //        var request = await _context.Requests.SingleOrDefaultAsync(m => m.ID == id);
    //        if (request == null)
    //        {
    //            return NotFound();
    //        }

    //        _context.Requests.Remove(request);
    //        await _context.SaveChangesAsync();

    //        return Ok(request);
    //    }

    //    private bool RequestExists(int id)
    //    {
    //        return _context.Requests.Any(e => e.ID == id);
    //    }
    //}
}