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

        private readonly UnitOfWork unitOfWork;

        public AmendmentsController(PlutoContext plutoContext)
        {
            unitOfWork = new UnitOfWork(plutoContext);
        }

        // GET: api/Amendments
        [HttpGet]
        public async Task<IEnumerable<Amendment>> GetAmendment()
        {
            try
            {
                IEnumerable<Amendment> obj = await unitOfWork.Amendment.GetAllWithReasonsAsync();
                return obj;
            }
            catch (Exception ex)
            {
                return null;
            }

            // return _amendmentRepository.GetAll();
        }

        // GET: api/Amendments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAmendment([FromRoute] int id)
        {
            Amendment amendment =await unitOfWork.Amendment.GetWithReasons(a => a.ID == id);
            if (amendment == null)
            {
                return BadRequest();
            }
            //return amendment;
            return Ok(amendment);
        }


        //POST: api/Amendments
        [HttpPost]
        public async Task<IActionResult> PostAmendment([FromBody] Request request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await unitOfWork.Request.AddAsyn(request);

            foreach (Amendment amendment in request.Amendments)
            {
                amendment.RequestID = request.ID;
            }
            unitOfWork.Amendment.AddRangeAsyn(request.Amendments);
            await unitOfWork.CompleteAsync();
            return CreatedAtAction("GetAmendment", new { id = request.ID }, request);
        }

        // PUT: api/Amendments/5
        [HttpPut]
        public async Task<IActionResult> PutAmendment( [FromBody] Request request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (request.ID != request.Amendments[0].RequestID)
            {
                return BadRequest();
            }
            await unitOfWork.Amendment.UpdateAsyn(request.Amendments[0], request.Amendments[0].ID);
            await unitOfWork.CompleteAsync();  

            return NoContent();
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

        private bool AmendmentExists(int id)
        {
            return unitOfWork.Amendment.Exists(e => e.ID == id);
        }
    }
}