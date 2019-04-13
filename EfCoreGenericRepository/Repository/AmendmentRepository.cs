
using EfCoreGenericRepository.Interfaces;
using EfCoreGenericRepository.Models;
using Microsoft.EntityFrameworkCore;
 
using System;
using System.Collections.Generic;
using System.Linq;
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

        public   Amendment GetWithReasons(Func<Amendment, bool> predicate)
        {
            return   _context.Amendments
                   .Include(a => a.AmendmentReason)
                   .Where(predicate).FirstOrDefault(); 
        }
    }
}
