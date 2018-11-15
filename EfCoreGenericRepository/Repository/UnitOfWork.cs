 
using EfCoreGenericRepository.Interfaces;
using EfCoreGenericRepository.Models;

namespace EfCoreGenericRepository.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PlutoContext _context;

        public UnitOfWork(PlutoContext context)
        {
            _context = context;
            Request = new RequestRepository(_context);
            RequestType = new RequestTypeRepository(_context);
            Amendment = new AmendmentRepository(_context);
            employeeInfoView = new EmployeeInfoViewRepository(_context);
        } 

        public IRequestRepository Request { get; private set; }

        public IRequestTypeRepository RequestType { get; private set; }

        public IAmendmentRepository Amendment { get; private set; }

        public IEmployeeInfoViewRepository employeeInfoView { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public async System.Threading.Tasks.Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}