
using EfCoreGenericRepository.DataAccess;
using System;


namespace EfCoreGenericRepository.Models
{
    public interface IUnitOfWork : IDisposable
    {
        IBlogRepository Blog { get; }

      //  IAuthorRepository Authors { get; }
        int Complete();
    }
}