
using EfCoreGenericRepository.Interfaces;
using EfCoreGenericRepository.Models;
using Microsoft.EntityFrameworkCore;
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EfCoreGenericRepository.Repository
{
    public class AmendmentRepository : GenericRepository<Amendment>, IAmendmentRepository
    {
        public AmendmentRepository(PlutoContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Amendment>> GetAllWithReasonsAsync()
        {
            return await _context.Amendments.Include(a => a.AmendmentReason).ToListAsync();
        }

        public async Task<Amendment> GetWithReasons(Expression<Func<Amendment, bool>> predicate )
        {
            return await _context.Amendments
                   .Include(a => a.AmendmentReason)
                   .SingleOrDefaultAsync(predicate);
      
        }
    }
}
