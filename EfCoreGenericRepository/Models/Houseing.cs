using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EfCoreGenericRepository.Models
{
    [Table("ESS_Housing")]
    public class Housing
    {
        public int ID { get; set; }

        public string HouseingDetails { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal MonthlyInstallment { get; set; }

        public int NoOfInstallment { get; set; }

      //  public string FilePath;

        public string ContractPeriod { get; set; }

        public DateTime LoanStartDate { get; set; }

        public string LOANTYPECODE { get; set; }

        public int RequestID { get; set; }
        public virtual Request Request { get; set; }
    }
}
