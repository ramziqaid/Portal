using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EfCoreGenericRepository.Models
{
    [Table("ESS_Housing")]
    public class PersonalInfo
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Loan Start Date required")]
        [Display(Name = "Loan Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime LoanStartDate { get; set; }

        public string Description { get; set; }
         

        [Display(Name = "Request ID")]
        public int RequestID { get; set; }
        public virtual Request Request { get; set; }
    }
}
