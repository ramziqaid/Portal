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
    [Produces("application/json")]
    [Route("api/BankInfo")]
    public class BankInfoController : Controller
    {
        private readonly UnitOfWork unitOfWork;

        public BankInfoController(PlutoContext plutoContext)
        {

            unitOfWork = new UnitOfWork(plutoContext);
        }

        [HttpGet("{EmployeeID}")]
        public async Task<IActionResult> BankInfo( long EmployeeID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BankInfo request = await unitOfWork.BankInfo.GetAsync(EmployeeID);

            if (request == null)
            {
                return NotFound();
            }
            return Ok(request);
        }
 
       
        // POST: api/Requests
        //[Route("api/Requests")]
        [HttpPost]
        public async Task<IActionResult> PostBankInfo([FromBody] Request request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await unitOfWork.Request.AddAsyn(request);

            foreach (RequestStage stage in request.RequestStages)
            {
                stage.RequestID = request.ID;
            }
            if (request.Amendments != null)
            {
                foreach (Amendment amendment in request.Amendments)
                {
                    amendment.RequestID = request.ID;
                }
            }
            if (request.Housings != null)
            {
                foreach (Housing housing in request.Housings)
                {
                    housing.RequestID = request.ID;
                }

            }

            unitOfWork.RequestStage.AddRangeAsyn(request.RequestStages);
            unitOfWork.Amendment.AddRangeAsyn(request.Amendments);
            unitOfWork.Housing.AddRangeAsyn(request.Housings);

            await unitOfWork.CompleteAsync();
            return CreatedAtAction("GetAmendment", new { id = request.ID }, request);
        }


        // PUT: api/Requests/5
        [HttpPut]
        public async Task<IActionResult> PutBankInfo([FromBody] Request request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (request.Amendments != null)
            {
                if (request.ID != request.Amendments[0].RequestID)
                {
                    return BadRequest();
                }
            }

            if (request.Housings != null)
            {
                if (request.ID != request.Housings[0].RequestID)
                {
                    return BadRequest();
                }
            }

            bool exits = unitOfWork.Request.Exists(d => d.ID == request.ID);
            if (!exits)
            {
                return NotFound();
            }
            await unitOfWork.Request.UpdateAsyn(request, request.ID);
            if (request.Amendments != null) await unitOfWork.Amendment.UpdateAsyn(request.Amendments[0], request.Amendments[0].ID);
            if (request.Housings != null) await unitOfWork.Housing.UpdateAsyn(request.Housings[0], request.Housings[0].ID);

            await unitOfWork.CompleteAsync();

            return NoContent();

        }

        //// DELETE: api/Requests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequest([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool exits = unitOfWork.Request.Exists(d => d.ID == id);
            if (!exits)
            {
                return NotFound();
            }

            //var amendment = await unitOfWork.Amendment.GetAsync(id); 
            //if (amendment == null)
            //{
            //    return NotFound();
            //}
            //await unitOfWork.Amendment.DeleteAsyn(amendment);

            var request = await unitOfWork.Request.GetAsync(id);
            if (request == null)
            {
                return NotFound();
            }
            await unitOfWork.Request.DeleteAsyn(request);

            await unitOfWork.CompleteAsync();


            return Ok();

        }

        //private bool RequestExists(int id)
        //{
        //    return _context.Requests.Any(e => e.ID == id);
        //}
    }
}