

using EfCoreGenericRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EfCoreGenericRepository.Interfaces
{
    public interface IAmendmentRepository : IGenericRepository<Amendment>
    {
       Task< IEnumerable<Amendment>> GetAllWithReasonsAsync();
      Task  <Amendment> GetWithReasons(Expression<Func<Amendment, bool>> predicate );
    }

}
