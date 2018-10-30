using Portal.Data.Interfaces;
using Portal.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Data.Repository
{
    public class AmendmentRepository : Repository<Amendment>, IAmendmentRepository
    {
        public AmendmentRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
