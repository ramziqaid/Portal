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
    [Route("api/RequestStage")]
    public class RequestStageController : Controller
    {
        private readonly UnitOfWork unitOfWork;

        public RequestStageController(PlutoContext plutoContext)
        { 
            unitOfWork = new UnitOfWork(plutoContext);
        }
         
        //[Route("api/Requests/RequestStage")]
        [HttpPost]
        public async Task<IActionResult> PostRequestStage([FromBody] RequestStage requestStage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            } 
            await unitOfWork.RequestStage.AddAsyn(requestStage);

            await unitOfWork.CompleteAsync();
            return NoContent();
        }

        // PUT: api/Requests/5
        [HttpPut]
        public async Task<IActionResult> PutRequestStage( [FromBody] Request request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (request.ID != request.Amendments[0].RequestID)
            {
                return BadRequest();
            }
            bool exits = unitOfWork.Request.Exists(d => d.ID == request.ID);
            if (!exits)
            {
                return NotFound();
            }
            await unitOfWork.Request.UpdateAsyn(request, request.ID);
            await unitOfWork.Amendment.UpdateAsyn(request.Amendments[0], request.Amendments[0].ID);

            await unitOfWork.CompleteAsync();

            return NoContent();
             
        }

        //// DELETE: api/Requests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequestStage([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool exits =  unitOfWork.Request.Exists(d =>d.ID==id);
            if (! exits)
            {
                return NotFound();
            }
 

            var request = await unitOfWork.Request.GetAsync( id);
            if (request == null)
            {
                return NotFound();
            }
            await unitOfWork.Request.DeleteAsyn(request);

            await unitOfWork.CompleteAsync();


            return Ok();
             
        }

        
    }
}