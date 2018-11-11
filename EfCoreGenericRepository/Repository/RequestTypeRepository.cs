

using EfCoreGenericRepository.Interfaces;
using EfCoreGenericRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfCoreGenericRepository.Repository
{
    public class RequestTypeRepository : GenericRepository<RequestType>, IRequestTypeRepository
    {
        public RequestTypeRepository(PlutoContext context) : base(context)
        {
        }
    }
}
