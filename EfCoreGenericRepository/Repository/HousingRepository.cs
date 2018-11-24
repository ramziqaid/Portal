
using EfCoreGenericRepository.Interfaces;
using EfCoreGenericRepository.Models;
using Microsoft.EntityFrameworkCore;
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfCoreGenericRepository.Repository
{
    public class HousingRepository : GenericRepository<Housing>, IHousingRepository
    {
        public HousingRepository(PlutoContext context) : base(context)
        {

        }

        
    }
}
