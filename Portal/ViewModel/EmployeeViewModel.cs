using EfCoreGenericRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.ViewModel
{
    public class EmployeeViewModel
    {
        public BankInfo bankInfo { get; set; }

        public IEnumerable<Author> Authors { get; set; } 
    }
}
