
using EfCoreGenericRepository.Interfaces;
using EfCoreGenericRepository.Models;
using Microsoft.EntityFrameworkCore;
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfCoreGenericRepository.Repository
{
    public class BankInfoRepository : GenericRepository<BankInfo>, IBankInfoRepository
    {
        public BankInfoRepository(PlutoContext context) : base(context)
        {

        } 
        
    }
}
