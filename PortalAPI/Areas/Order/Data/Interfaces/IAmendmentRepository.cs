﻿

using PortalAPI.Areas.Order.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalAPI.Areas.Order.Data.Interfaces
{
    public interface IAmendmentRepository : IRepository<Amendment>
    {
        IEnumerable<Amendment> GetWithReasons(Func<Amendment, bool> predicate);
    }

}
