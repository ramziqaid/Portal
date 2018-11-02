using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Areas.Order.Data.Model
{
    [Table("ESS_RequestType")]
    public class RequestType
    {
        [Column(Order = 0)]
        public int id { get; set; }
          [Column(Order = 1)]
        public string RequestName { get; set; }
        [Column(Order = 2)]
        public string ControllerName { get; set; }
        public Nullable<int> RequestGroupID { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string icons { get; set; } 

        public virtual List<Request> Requests { get; set; }
    }
}
