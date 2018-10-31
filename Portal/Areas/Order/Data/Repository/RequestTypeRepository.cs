using Portal.Areas.Order.Data.Interfaces;
using Portal.Areas.Order.Data.Model;
using Portal.Data; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Areas.Order.Data.Repository
{
    public class RequestTypeRepository : Repository<RequestType>, IRequestTypeRepository
    {
        public RequestTypeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
