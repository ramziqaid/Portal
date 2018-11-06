using PortalAPI.Areas.Order.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalAPI.Areas.Order.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IRequestRepository request { get; }
        IAmendmentRepository amendment { get; }
      
        int Complete();
    }
}
