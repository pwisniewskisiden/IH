using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
         var res1 =  Regex.IsMatch("DealerPartsMaster_FULL_201605181526.txt", "DealerPartsMaster_FULL_*.txt", RegexOptions.IgnoreCase);
         var res2 =  Regex.IsMatch("DeleteMEDealerPartsMaster_FULL_201605181423.txt", "DealerPartsMaster_FULL_*.txt", RegexOptions.IgnoreCase);

         var res3 = Regex.IsMatch("DealerPartsMaster_FULL_201605181526.txt", @"\bD\S*e\t", RegexOptions.IgnoreCase);
         var res4 = Regex.IsMatch("DeleteMEDealerPartsMaster_FULL_201605181423.txt", @"\bD\S*e\t", RegexOptions.IgnoreCase);

            
        }
    }
}
