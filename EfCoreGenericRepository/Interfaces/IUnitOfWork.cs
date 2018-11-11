
using EfCoreGenericRepository.Interfaces;
using System;


namespace EfCoreGenericRepository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRequestRepository Request { get; }
        IRequestTypeRepository RequestType { get; }
        IAmendmentRepository Amendment { get; }

        int Complete();
    }
}