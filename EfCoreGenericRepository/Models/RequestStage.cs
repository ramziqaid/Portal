
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EfCoreGenericRepository.Models
{

    [Table("ESS_WF_OrderStage")]
    public class RequestStage
    {
        [Column(Order = 0)]
        public int ID { get; set; } 

        [Required]
        [Display(Name = "Request ID")]
        public int RequestID { get; set; }
        public virtual Request Request { get; set; }

        [Required]
        [Column(Order = 2)]
        public int StageTypeID { get; set; }
        //public virtual AmendmentReason AmendmentReason { get; set; }


        [Display(Name = "Justification ")]
        [MaxLength(500)]
        public string Justification { get; set; }

        [Display(Name = "ActionName ")]
        public string ActionName { get; set; }

       
        [Display(Name = "Create By ")]
        [Required(ErrorMessage = "CreateBy")]
        public long EmployeeID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreateDate { get; set; }
    }






}
 