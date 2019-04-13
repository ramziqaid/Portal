

using EfCoreGenericRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfCoreGenericRepository.Interfaces
{
    public interface IAmendmentRepository : IGenericRepository<Amendment>
    {
       Task< IEnumerable<Amendment>> GetAllWithReasonsAsync();
        Amendment GetWithReasons(Func<Amendment, bool> predicate);
    }

}
