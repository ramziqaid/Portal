
using Microsoft.EntityFrameworkCore;
using PortalAPI.Areas.Order.Data.Interfaces;
using PortalAPI.Areas.Order.Data.Model;
using PortalAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalAPI.Areas.Order.Data.Repository
{
    public class AmendmentRepository : Repository<Amendment>, IAmendmentRepository
    {
        public AmendmentRepository(ApplicationDbContext context) : base(context)
        {

        }

        public IEnumerable<Amendment> GetWithReasons(Func<Amendment, bool> predicate)
        {
            return _context.Amendment
                   .Include(a => a.AmendmentReason)
                   .Where(predicate); 
        }
    }
}
