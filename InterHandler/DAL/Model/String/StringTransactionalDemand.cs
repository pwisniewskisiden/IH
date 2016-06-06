using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class StringTransactionalDemand : FileData
    {
        public string RowTransactionType { set; get; }
        public string ItemCode  { set; get; }
        public string WarehouseCode { set; get; }
        public string WarehouseGroupCode { set; get; }
        public string SalesOrderNumber { set; get; }
        public string SalesOrderLineNumber { set; get; }

        public string ExtractionDate { set; get; }
        public string OrderedRequestedQuantity { set; get; }
        public string DeliveredSuppliedQuantity { set; get; }
        public string DemandDate { set; get; }

        public string CustomerCode  { set; get; }
        public string UseForForecasting { set; get; }
        public string UseForServiceLevel { set; get; }
        public string UseForClassification { set; get; }
        public string StockAtDemandDate  { set; get; }
        public string FreeText1 { set; get; }
        public string FreeText2 { set; get; }

        public string FreeText3 { set; get; }
        public string FreeText4 { set; get; }
        public string FreeText5 { set; get; }

        public StringTransactionalDemand()
        {
        }

        StringTransactionalDemand(string line)
        {
            ReadFromLine(line);
        }

        public override string[] Verify()
        {
            throw new NotImplementedException();
        }
    }
}
