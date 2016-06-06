using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class ExtensionMethods
    {
        public static string CutDownTo(this string value, int ile)
        {
            if (value == null) return string.Empty;
            if (value.Length <= ile) return value;
            else return value.Substring(0, ile);
        }

        public static string DateToString(this DateTime? value)
        {
            if (value != null) return((DateTime)value).ToString("yyyy-MM-dd");
            return string.Empty;
        }

        public static string DateTimeToString(this DateTime? value)
        {
            if (value != null) return ((DateTime)value).ToString("yyyy-MM-ddTHH\\:mm");
            return string.Empty;
        }

        public static string DecimalToString(this Decimal? value,int prec)
        {
            try
            {
                if (value != null) return Decimal.Round((decimal)value, prec).ToString(CultureInfo.InvariantCulture);
            }
            catch { }
                  
            return string.Empty;
       }


    }
}
