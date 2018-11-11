

using EfCoreGenericRepository.Interfaces;
using EfCoreGenericRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace EfCoreGenericRepository.Repository
{
    public class RequestRepository : GenericRepository<Request>, IRequestRepository
    {
        public RequestRepository(PlutoContext context) : base(context)
        {
        }
       
    }
}
