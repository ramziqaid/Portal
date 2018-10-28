using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portal.Data.Interfaces;
using Portal.Data.Model;
using Portal.ViewModel;

namespace PortalAspCore.Controllers
{
    public class EFormController : Controller
    {
        private readonly IRequestRepository _requestRepository;

        public EFormController(IRequestRepository requestRepository )
        {
            _requestRepository = requestRepository;
        }


        public IActionResult List(int? TypeID)
        {
            IEnumerable<Request> requests;
            if (TypeID == null)
            {
                requests = _requestRepository.GetAll();
            }
            else
            {
                requests = _requestRepository.Find(p => p.RequestGroupID == TypeID);
            }
            RequestListViewModel requestListViewModel = new RequestListViewModel
            {
                Requests = requests,
                TitleCategory = ""
            };
            return View(requestListViewModel);
        }

    }
}