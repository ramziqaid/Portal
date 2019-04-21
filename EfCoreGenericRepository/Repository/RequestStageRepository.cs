
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
    public class RequestStageRepository : GenericRepository<RequestStage>, IRequestStageRepository
    {
        public RequestStageRepository(PlutoContext context) : base(context)
        {

        }

        
    }
}
