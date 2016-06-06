using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Model
{
    public class BLTransactionalDemand 
    {
        public string RowTransactionType { set; get; }
        public string ItemCode { set; get; }
        public string WarehouseCode { set; get; }
        public string WarehouseGroupCode { set; get; }
        public string SalesOrderNumber { set; get; }
        public string SalesOrderLineNumber { set; get; }

        public DateTime ExtractionDate { set; get; }
        public int OrderedRequestedQuantity { set; get; }
        public int DeliveredSuppliedQuantity { set; get; }
        public DateTime DemandDate { set; get; }

        public string CustomerCode { set; get; }
        public string UseForForecasting { set; get; }
        public string UseForServiceLevel { set; get; }
        public string UseForClassification { set; get; }
        public int StockAtDemandDate { set; get; }
        public string FreeText1 { set; get; }
        public string FreeText2 { set; get; }

        public string FreeText3 { set; get; }
        public string FreeText4 { set; get; }
        public string FreeText5 { set; get; }
    }
}
