 
using EfCoreGenericRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalAPI.ViewModel
{
    public class RequestListViewModel
    {
        public IEnumerable<RequestType> RequestsType { get; set; }
        public string TitleCategory { get; set; }
    }
}
