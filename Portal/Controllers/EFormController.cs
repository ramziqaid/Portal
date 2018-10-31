using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portal.Areas.Order.Data.Interfaces;
using Portal.Areas.Order.Data.Model;
using Portal.ViewModel;

namespace Portal.Controllers
{
    public class EFormController : Controller
    {
        private readonly IRequestTypeRepository _requestRepository;

        public EFormController(IRequestTypeRepository requestRepository )
        {
            _requestRepository = requestRepository;
        }

        public IActionResult List(int? TypeID)
        {
            IEnumerable<RequestType> requestsType;
            if (TypeID == null)
            {
                requestsType = _requestRepository.GetAll();
            }
            else
            {
                requestsType = _requestRepository.Find(p => p.RequestGroupID == TypeID);
            }
            RequestListViewModel requestListViewModel = new RequestListViewModel
            {
                RequestsType = requestsType,
                TitleCategory = ""
            };
            return View(requestListViewModel);
        }

    }
}