﻿using Portal.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.ViewModel
{
    public class RequestListViewModel
    {
        public IEnumerable<Request> Requests { get; set; }
        public string TitleCategory { get; set; }
    }
}
