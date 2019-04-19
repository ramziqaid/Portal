using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EfCoreGenericRepository.Models
{
    [NotMapped]
    [Table("ESS_EmployeeInfoView2")]
    public partial class EmployeeInfoView
    {
        //public long ID { get; set; }

       
        public long  EmployeeID{ get; set; }

        [Display(Name = "Personnel Number")]
        public string  Personnelnumber{ get; set; }

        public string  PASSWORD{ get; set; }

        public long  PERSON{ get; set; }

        public string  ArabicName{ get; set; }

        public string  EnglishName{ get; set; }

        public string  UserName{ get; set; }

        public int  ACTIVE{ get; set; }

        public decimal  BASICSALARY{ get; set; }

        public decimal  GOSISALARY{ get; set; }

        public decimal  GROSSSALARY{ get; set; }

        public string  CONTRACTCODE{ get; set; }

        public int  CONTRACTTYPE{ get; set; }

        public System.DateTime  ContractStart{ get; set; }

        public System.DateTime  ContractEnd{ get; set; }

        public System.DateTime  JOININGDATE{ get; set; }

        public decimal  NOOFYEARS{ get; set; }

        public System.DateTime  BIRTHDATE{ get; set; }

        public string  EDUCATION{ get; set; }

        public string  NATIONALITY{ get; set; }

        public string  RELGION{ get; set; }

        public string  SPONSERSHIP{ get; set; }

        public int  STATUS{ get; set; }

        public int  GenderID{ get; set; }

        public string  GENDERName{ get; set; }

        public System.Nullable<long>  ManagerID{ get; set; }

        public string  DirectManagerName{ get; set; }

        public string  Email{ get; set; }

        public string  Phone{ get; set; }

        public string  Fax{ get; set; }

        public string  Company{ get; set; }

        public int IsManager { get; set; }

        public int  IsDepartmentManager{ get; set; }

        public int  VacationBalance{ get; set; }

        public int  WORKERGROUP{ get; set; }

        public System.Nullable<long>  DepartmentID{ get; set; }

        public string  DepartmentName{ get; set; }

        public System.Nullable<System.DateTime>  IqamaDate{ get; set; }

        public System.Nullable<System.DateTime>  IqamaExpiryDate{ get; set; }

        public string  IqamaID{ get; set; }

        public System.DateTime  lastReturnVacationDate{ get; set; }

        public string  Position{ get; set; }

        public System.Nullable<long>  PositionID{ get; set; }

        public string  PROFILEID{ get; set; }

        public virtual List<Request> Requests { get; set; }
        
    }
}
