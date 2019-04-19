

using EfCoreGenericRepository.Interfaces;
using EfCoreGenericRepository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Transactions;

namespace EfCoreGenericRepository.Repository
{
    public class RequestRepository : GenericRepository<Request>, IRequestRepository
    {
        public RequestRepository(PlutoContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Request>> GetRequestsWithAllData(Expression<Func<Request, bool>> predicate)
        {
            return await _context.Requests
                 .Include(c => c.RequestType)
                 .Include(c => c.Employee)
                 .Include(c => c.Amendments).ThenInclude(a =>a.AmendmentReason)
                 .Where(predicate).ToListAsync(); 

        }
    }
}
