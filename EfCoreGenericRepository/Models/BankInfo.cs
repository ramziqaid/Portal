using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EfCoreGenericRepository.Models
{
    [Table("HCMWORKERBANKACCOUNT")]
    public class BankInfo
    {

        public long RECID { get; set; }
        [Key]
        public long WORKER { get; set; }
      public string DATAAREAID { get; set; }
        public long PARTITION { get; set; }
        public long LOCATION { get; set; }

        public string ACCOUNTNUM { get; set; }
        public string IBAN { get; set; }
        public string SWIFTCODE { get; set; }
        public string NAME { get; set; }
        public string BENEFICIARYNAME { get; set; } 

        //public string ACCOUNTID { get; set; }

        //public string BANKGROUPID { get; set; }

        //public string REGISTRATIONNUM { get; set; }

        //public string PHONE { get; set; }

        //public string TELEFAX { get; set; }

        //public string CONTACTPERSON { get; set; }

        //public string EMAIL { get; set; }

        //public string URL { get; set; }

        //public string TELEX { get; set; }

        //public string CELLULARPHONE { get; set; }

        //public string PHONELOCAL { get; set; }

        //public string BANKGROUPDATAAREAID { get; set; }

        //public int BANKACCOUNTTYPE { get; set; }

        //public int BANKCODETYPE { get; set; }

        //public int CASH { get; set; } 

        //public int PRIORITY { get; set; } 

        //public string IFSCCODE { get; set; }

        //public string SORTCODE { get; set; }
         

        //public string BANKCOUNTRY { get; set; }

        //public System.DateTime MODIFIEDDATETIME { get; set; }

        //public string MODIFIEDBY { get; set; }

        //public System.DateTime CREATEDDATETIME { get; set; }

        //public string CREATEDBY { get; set; } 

        //public int RECVERSION { get; set; } 

        //public string FilePath { get; set; }
    }
}
