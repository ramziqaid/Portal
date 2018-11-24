using EfCoreGenericRepository.Models; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.ViewModel
{
    public class RequestViewModel
    { 
        public Request Request { get; set; }
        public IEnumerable<EmployeeInfoView> employeeInfos { get; set; }

        public Amendment Amendment { get; set; }
    }
}
