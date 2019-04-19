
using EfCoreGenericRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EfCoreGenericRepository.Interfaces
{
    public interface IRequestRepository : IGenericRepository<Request>
    {

        Task<IEnumerable<Request>> GetRequestsWithAllData(Expression<Func<Request, bool>> predicate);
    }

}
