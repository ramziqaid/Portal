

using PortalAPI.Areas.Order.Data.Interfaces;
using PortalAPI.Areas.Order.Data.Model;
using PortalAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalAPI.Areas.Order.Data.Repository
{
    public class RequestTypeRepository : Repository<RequestType>, IRequestTypeRepository
    {
        public RequestTypeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
