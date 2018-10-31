using Microsoft.ApplicationInsights.AspNetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Areas.Order.Data.Model
{

    [Table("ESS_Amendment")]
    public class Amendment
    {
        public int ID { get; set; }
        public int DocumentID { get; set; }
        public int RequestID { get; set; }

        [Required]
        public int AmendmentReasonId { get; set; }
        public Nullable<int> MonthYear { get; set; }
        public Nullable<int> MonthDate { get; set; }
        public Nullable<int> MonthDay { get; set; }

        [Display(Name = "Justification ")]
        [MaxLength(500)]
        public string Description { get; set; }
        public string Time { get; set; }
        public string TimeIn { get; set; }
        public string TimeOut { get; set; }

        [Required]
        [Display(Name = "Reason ")]
        public string Type { get; set; }

        [Display(Name = "Attachment ")]
        public string FilePath { get; set; } 

        public string CreatedBy { get; set; } 
        public string CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }

        public virtual AmendmentReason AmendmentReason { get; set; }
        public virtual Request ESS_Requests { get; set; }
        public virtual RequestType ESS_RequestType { get; set; }

        [NotMapped]
  
        [Display(Name = "Select Date ")]
        [DataType(DataType.Date)]
        public DateTime? SelectDate { get; set; }
    }
}
