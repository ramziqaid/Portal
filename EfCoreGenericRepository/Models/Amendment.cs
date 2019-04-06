 
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EfCoreGenericRepository.Models
{

    [Table("ESS_Amendment")]
    public class Amendment
    {
        [Column(Order = 0)]
        public int ID { get; set; }

        [Required]
        [Column(Order = 1)]
        public int AmendmentReasonId { get; set; }
        [Display(Name = "Reason")]
        public virtual AmendmentReason AmendmentReason { get; set; }


        [Display(Name = "Type ")]
        [Required(ErrorMessage = "Type required")]
        [Column(Order = 2)]
        public string Type { get; set; }

        [Column(Order = 3)]
        [Required(ErrorMessage = "Time required")]
        public string Time { get; set; }

        [Required]
        [Display(Name = "Select Date ")]
        [DataType(DataType.Date)]
        public DateTime? SelectDate { get; set; }

        [Required]
        [Display(Name = "Justification ")]
        [MaxLength(500)]
        public string Description { get; set; } 
         

        [Display(Name = "Attachment ")]
        public string FilePath { get; set; }

        public string CreatedBy { get; set; }

        [Display(Name = "Create Date ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public string CreatedDate { get; set; }

        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; } 


        public int RequestID { get; set; }
        public virtual Request Request { get; set; }

      

    }
}
