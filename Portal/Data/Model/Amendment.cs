using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Data.Model
{

    [Table("ESS_HR_Amendment")]
    public class Amendment
    {
        public int ID { get; set; }
        public Nullable<int> MonthYear { get; set; }
        public Nullable<int> MonthDate { get; set; }
        public Nullable<int> MonthDay { get; set; }
        public string Description { get; set; }
        public string Time { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
        public string TimeIn { get; set; }
        public string TimeOut { get; set; }
        public string Type { get; set; }
        public string FilePath { get; set; }

        public int AmendmentReasonId { get; set; }
        public virtual AmendmentReason AmendmentReason { get; set; }
       
        public int DocumentID { get; set; }
        public virtual Document ESS_Documents { get; set; }

        public int RequestID { get; set; }
        public virtual Request ESS_Requests { get; set; }

    }
}
