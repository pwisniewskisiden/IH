using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Model
{
    public class BLOpenPurchaseOrders
    {
        public string RowTransactionType { get; set; }

        public string ItemCode { get; set; }
        public string WarehouseCode { get; set; }
        public string WarehouseGroupCode { get; set; }
        public string OrderNumber { get; set; }
        public string OrderLineNumber { get; set; }
        public DateTime ExtractionDate { get; set; }
        public string SupplierCode { get; set; }
        public int OrderQuantity { get; set; }
        public DateTime OrderDate { get; set; }

        public DateTime RequestedDate { get; set; }
        public int ReceivedQuantity { get; set; }
        public DateTime ReceivedDate { get; set; }
        public string FreeText1 { get; set; }
        public string FreeText2 { get; set; }
        public string FreeText3 { get; set; }
        public string FreeText4 { get; set; }
        public string FreeText5 { get; set; }
    }
}
