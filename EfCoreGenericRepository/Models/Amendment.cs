
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
        [Display(Name = "Reason")]
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
        [Display(Name = "Select Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime SelectDate { get; set; }

        //[Required]
        //[Display(Name = "Select Date")
        //[RegularExpression(@"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$", ErrorMessage = "Invalid date format.")]
        //public string SelectDate { get; set; }

        [Required]
        [Display(Name = "Justification ")]
        [MaxLength(500)]
        public string Description { get; set; }


        [Display(Name = "Attachment ")]
        public string FilePath { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }


        public int RequestID { get; set; }
        public virtual Request Request { get; set; }



    }
}
