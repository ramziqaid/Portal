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


namespace PortalAPI.Areas.Order.Controllers
{
    [Produces("application/json")]
    [Route("api/Amendments")]
    public class AmendmentsController : Controller
    {

        private readonly IRequestRepository _requestRepository;
        private readonly IAmendmentRepository _amendmentRepository;
        private readonly UnitOfWork unitOfWork;

        public AmendmentsController(PlutoContext plutoContext, IRequestRepository requestRepository, IAmendmentRepository amendmentRepository)
        {
            _requestRepository = requestRepository;
            _amendmentRepository = amendmentRepository;
            unitOfWork = new UnitOfWork(plutoContext);
        }

        // GET: api/Amendments
        [HttpGet]
        public IEnumerable<Amendment> GetAmendment()
        {
            return _amendmentRepository.GetAll();
        }

        // GET: api/Amendments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAmendment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var amendment = _amendmentRepository.GetWithReasons(a => a.ID == id);
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
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //if (id != amendment.ID)
            //{
            //    return BadRequest();
            //}

            //_context.Entry(amendment).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!AmendmentExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return NoContent();
        }

        //POST: api/Amendments
        [HttpPost]
        public async Task<IActionResult> PostAmendment([FromBody] Request request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            } 
            unitOfWork.Request.Add(request); 
            foreach (Amendment amendment in request.Amendments)
            {
                amendment.RequestID = request.ID;
            } 
            unitOfWork.Amendment.AddRangeAsyn(request.Amendments);
            await unitOfWork.CompleteAsync(); 

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

            var amendment = await unitOfWork.Amendment.GetAsync(id);// _context.Amendment.SingleOrDefaultAsync(m => m.ID == id);
            if (amendment == null)
            {
                return NotFound();
            }
            await unitOfWork.Amendment.DeleteAsyn(amendment);
            await unitOfWork.CompleteAsync(); 
            

            return Ok(amendment);
        }

        //private bool AmendmentExists(int id)
        //{
        //    return _context.Amendment.Any(e => e.ID == id);
        //}
    }
}