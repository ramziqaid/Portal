using EfCoreGenericRepository.Models; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.ViewModel
{
    public class AmendmentViewModel
    {
        public Request request { get; set; }
        public Amendment amendment { get; set; }
        public IEnumerable<EmployeeInfoView> employeeInfos { get; set; }
    }
}
