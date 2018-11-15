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

using PortalAPI.ViewModel;

namespace PortalAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/EForm")]
    public class EFormController : Controller
    {
        private readonly IRequestTypeRepository _requestRepository;
        private readonly UnitOfWork unitOfWork;

        public EFormController(IRequestTypeRepository requestRepository, PlutoContext plutoContext)
        {
            _requestRepository = requestRepository;
            unitOfWork = new UnitOfWork(plutoContext);
        }

        // GET: api/EForm

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<RequestType> requestsType;
            requestsType = _requestRepository.GetAll();
            return Ok(requestsType);
        }

        [Route("api/EForm/GetFirst")]
        [HttpGet]
        public async Task<IActionResult> GetFirst()
        {
            IEnumerable<RequestType> requestsType;

            requestsType = _requestRepository.GetAll();

            return Ok(requestsType);
        }

        // GET: api/EForm/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            IEnumerable<RequestType> requestsType;
            requestsType = await unitOfWork.RequestType.FindAllAsync(p => p.RequestGroupID == id);
            return Ok(requestsType);
        }

        // POST: api/EForm
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/EForm/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
