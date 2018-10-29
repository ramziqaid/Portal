using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Data.Model
{
    [Table("ESS_Requests")]
    public class Request
    {
        public int id { get; set; }
        public string Department { get; set; }
        public string RequestName { get; set; }
        public string ControllerName { get; set; }
        public Nullable<int> RequestGroupID { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string icons { get; set; }

    }
}
