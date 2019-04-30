using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EfCoreGenericRepository.Models
{
   public class ESS_GetOrder
    {
        public int ID { get; set; }
        
        public long EmployeeID { get; set; }

        public int requestTypeID { get; set; }
        public int statusID { get; set; }
        public int? StageTypeID { get; set; } 
 
        public DateTime createdDate { get; set; }

        public string ControllerName { get; set; }
        

    }
}
