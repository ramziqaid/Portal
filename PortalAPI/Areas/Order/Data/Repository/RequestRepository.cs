
using PortalAPI.Areas.Order.Data.Interfaces;
using PortalAPI.Areas.Order.Data.Model;
using PortalAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace PortalAPI.Areas.Order.Data.Repository
{
    public class RequestRepository : Repository<Request>, IRequestRepository
    {
        public RequestRepository(ApplicationDbContext context) : base(context)
        {
        }
       
    }
}
