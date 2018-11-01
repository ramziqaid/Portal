﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Areas.Order.Data.Model
{
    [Table("ESS_Request")]
    public class Request
    {
        [Column(Order = 0)]
        public int ID { get; set; }
        [Column(Order =1)]
        public long EmployeeID { get; set; }
        [Column(Order = 2)]
        public Nullable<int> RequestTypeID { get; set; }
        [Column(Order = 3)]
        public Nullable<int> StatusID { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; } 
        public Nullable<bool> IsDelegate { get; set; }
        public Nullable<bool> IsDelegateApprove { get; set; }
        public Nullable<long> DelegateFromID { get; set; }
        public Nullable<long> DelegateToID { get; set; }

        public virtual ICollection<Amendment> Amendments { get; set; }

    }
}
