

using EfCoreGenericRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfCoreGenericRepository.Interfaces
{
    public interface IEmployeeInfoViewRepository : IGenericRepository<EmployeeInfoView>
    {
       // IEnumerable<Amendment> GetWithReasons(Func<Amendment, bool> predicate);
    }

}
