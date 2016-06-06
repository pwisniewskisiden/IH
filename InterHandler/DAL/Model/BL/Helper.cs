using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model.BL
{

    public static class Helper
    {


        public static string FileType(string modelName)
        {
           if (modelName == "DealerPartsMaster")   return "DealerPartsMaster_FULL_";
           if (modelName == "OpenPurchaseOrders")  return "Purchase_Order_FULL_";
           if (modelName == "TransactionalDemand") return "Transactional_Demand_PARTIAL_";
            return string.Empty;
        }

        public static string FileName(string modelName)
        {
            var timeStamp = DateTime.Now.ToString("yyyyMMddHHmm");

            if (modelName == "DealerPartsMaster")   return string.Format("DealerPartsMaster_FULL_{0}.txt", timeStamp);
            if (modelName == "OpenPurchaseOrders")  return string.Format("Purchase_Order_FULL_{0}.txt", timeStamp);
            if (modelName == "TransactionalDemand") return string.Format("Transactional_Demand_PARTIAL_{0}.txt", timeStamp);
            return string.Empty;
        }

    }

}
