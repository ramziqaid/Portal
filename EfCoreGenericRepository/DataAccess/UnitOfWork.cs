

using EfCoreGenericRepository.Models;

namespace EfCoreGenericRepository.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PlutoContext _context;

        public UnitOfWork(PlutoContext context)
        {
            _context = context;
            Blog = new BlogRepository(_context);
            //Authors = new AuthorRepository(_context);
        }

        public IBlogRepository Blog { get; private set; }

        //public IAuthorRepository Authors { get; private set; }

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