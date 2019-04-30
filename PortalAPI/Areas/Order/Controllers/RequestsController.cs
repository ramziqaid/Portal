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
    [Route("api/Requests")]
    public class RequestsController : Controller
    {
        private readonly UnitOfWork unitOfWork;

        public RequestsController(PlutoContext plutoContext)
        {

            unitOfWork = new UnitOfWork(plutoContext);
        }

        // GET: api/Requests
        [HttpGet]
        public async Task<IEnumerable<Request>> GetRequests()
        {
            try
            {
                IEnumerable<Request> obj = await unitOfWork.Request.GetAllIncluding(
                    c => c.Amendments
                    ).ToListAsync();
                return obj;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        // GET: api/Requests/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRequest([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            IEnumerable<Request> request = await unitOfWork.Request.GetRequestsWithAllData(a => a.ID == id);
                      
            if (request == null)
            {
                return NotFound();
            }
            return Ok(request.FirstOrDefault());
        }

        // GET: api/Requests/5
        [HttpGet]     
        [Route("GetRequestForManager/{employeeID}")]
        public async Task<IActionResult> GetRequestForManager([FromRoute] long employeeID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            } 

            IEnumerable<object> request =   unitOfWork.Request.getRequest();
            if (request == null)
            {
                return NotFound();
            }
           // return Json(new { data = requests });
            return Ok(request);
        }

        [HttpGet]
        [Route("GetRequestByType/{RequestTypeID}")]             
        public async Task<IActionResult> GetRequestByType([FromRoute] int RequestTypeID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IEnumerable<Request> obj = await unitOfWork.Request.GetRequestsWithAllData(a => a.RequestTypeID == RequestTypeID);

            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }

        // POST: api/Requests
        //[Route("api/Requests")]
        [HttpPost]
        public async Task<IActionResult> PostRequest([FromBody] Request request)
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
            foreach (RequestStage stage in request.RequestStages)
            {
                stage.RequestID = request.ID;
            }
            unitOfWork.Amendment.AddRangeAsyn(request.Amendments);
            unitOfWork.RequestStage.AddRangeAsyn(request.RequestStages);

            await unitOfWork.CompleteAsync();
            return CreatedAtAction("GetAmendment", new { id = request.ID }, request);             
        }

     
        // PUT: api/Requests/5
        [HttpPut]
        public async Task<IActionResult> PutRequest( [FromBody] Request request)
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
        public async Task<IActionResult> DeleteRequest([FromRoute] int id)
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

            //var amendment = await unitOfWork.Amendment.GetAsync(id); 
            //if (amendment == null)
            //{
            //    return NotFound();
            //}
            //await unitOfWork.Amendment.DeleteAsyn(amendment);

            var request = await unitOfWork.Request.GetAsync( id);
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