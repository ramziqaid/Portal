using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PortalAPI.Areas.Order.Data.Model
{
    
         [Table("ESS_AmendmentReasons")]
    public class AmendmentReason
    {
        public int ID { get; set; }
        public string AmendReasonEn { get; set; }
        public string AmendReasonAr { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }

        
        public virtual ICollection<Amendment> Amendments { get; set; }
    }
}
