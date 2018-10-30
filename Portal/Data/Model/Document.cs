using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Data.Model
{
    [Table("ESS_Documents")]
    public class Document
    {
        public int ID { get; set; }
        public long EmployeeID { get; set; }
        public Nullable<int> RequestTypeID { get; set; }
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
