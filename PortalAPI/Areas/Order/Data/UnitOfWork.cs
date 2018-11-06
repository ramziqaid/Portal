using PortalAPI.Areas.Order.Data.Interfaces;
using PortalAPI.Areas.Order.Data.Repository;
using PortalAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalAPI.Areas.Order.Data
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            request = new RequestRepository(_context);
            amendment = new AmendmentRepository(_context);
        }

        public IRequestRepository request { get; private set; }
        public IAmendmentRepository amendment { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
