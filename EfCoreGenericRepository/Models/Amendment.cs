﻿ 
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
        [Display(Name = "Type ")]
        [Column(Order = 1)]
        public string Type { get; set; }

        [Required]
        [Column(Order = 1)]
        public int AmendmentReasonId { get; set; }
        public virtual AmendmentReason AmendmentReason { get; set; }

        public Nullable<int> MonthYear { get; set; }
        public Nullable<int> MonthDate { get; set; }
        public Nullable<int> MonthDay { get; set; }

        [Display(Name = "Justification ")]
        [MaxLength(500)]
        public string Description { get; set; }

        public string TimeIn { get; set; }
        public string TimeOut { get; set; }

        [Display(Name = "Attachment ")]
        public string FilePath { get; set; }

        public string CreatedBy { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}")]
        public string CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }



        public int RequestID { get; set; }
        public virtual Request Request { get; set; }



        [NotMapped]

        [Display(Name = "Select Date ")]
        [DataType(DataType.Date)]
        public DateTime? SelectDate { get; set; }
    }
}