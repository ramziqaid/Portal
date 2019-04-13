using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Portal
{
    public class DateHelp
    {
        public static DateTime GetDefaultDate()
        {
            return DateTime.ParseExact("01/01/1900", GerigoinDateFormate(), CultureInfo.InvariantCulture);
            // return Convert.ToDateTime(,);// "dd/MM/yyyy";
        }

        public static DateTime GetDate(DateTime dt)
        { 
            string formatted = dt.ToString(GerigoinDateFormate());

            DateTime result = DateTime.ParseExact(formatted, GerigoinDateFormate(), CultureInfo.InvariantCulture);
            return result;
        }
        public static string GetDateStr(DateTime dt)
        {
            string formatted = dt.ToString(GerigoinDateFormate()); 
            
            return formatted;
        }

        public static DateTime GetDate(string dt)
        { 

            DateTime result = DateTime.ParseExact(dt, GerigoinDateFormate(), CultureInfo.InvariantCulture);
            return result;
        }
        public static string GerigoinDateFormate()
        {
            return "dd/MM/yyyy";
        }

    }
}
