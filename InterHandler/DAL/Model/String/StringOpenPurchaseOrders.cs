using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class StringOpenPurchaseOrders : FileData
    {
     
        public string RowTransactionType { get; set; }

        public string ItemCode { get; set; }
        public string WarehouseCode { get; set; }
        public string WarehouseGroupCode { get; set; }
        public string OrderNumber { get; set; }
        public string OrderLineNumber { get; set; }
        public string ExtractionDate  { get; set; }
        public string SupplierCode  { get; set; }
        public string OrderQuantity  { get; set; }
        public string OrderDate  { get; set; }

        public string RequestedDate { get; set; }
        public string ReceivedQuantity  { get; set; }
        public string ReceivedDate  { get; set; }
        public string FreeText1 { get; set; }
        public string FreeText2 { get; set; }
        public string FreeText3 { get; set; }
        public string FreeText4 { get; set; }
        public string FreeText5 { get; set; }

        public StringOpenPurchaseOrders()
        {
        }

        public StringOpenPurchaseOrders(string line) 
        {
            ReadFromLine(line);
        }

        public override string[] Verify()
        {
            throw new NotImplementedException();
        }

        public static string FileName()
        {
            var timeStamp = DateTime.Now.ToString("yyyyMMddHHmm");
            return string.Format("Purchase_Order_FULL_{0}.txt", timeStamp);
//          Purchase_Order_FULL_<datetimestamp>.txt,
//          where the < datetimestamp > is the date and time when the file was created in CCYYMMDDHHMM format.
//          < datetimestamp > should uniquely identify the file.
//          For example: Purchase_Order_FULL_201308091420.txt
        }
    }
}
