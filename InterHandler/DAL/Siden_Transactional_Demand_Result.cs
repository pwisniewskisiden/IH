//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    
    public partial class Siden_Transactional_Demand_Result
    {
        public string RowTransactionType { get; set; }
        public string ItemCode { get; set; }
        public string WarehouseCode { get; set; }
        public string WarehouseGroupCode { get; set; }
        public string SalesOrderNumber { get; set; }
        public short SalesOrderLineNumber { get; set; }
        public System.DateTime ExtractionDate { get; set; }
        public Nullable<decimal> OrderedRequestedQuantity { get; set; }
        public Nullable<decimal> DeliveredSuppliedQuantity { get; set; }
        public Nullable<System.DateTime> DemandDate { get; set; }
        public string CustomerCode { get; set; }
        public string UseForForecasting { get; set; }
        public string UseForServiceLevel { get; set; }
        public string UseForClassification { get; set; }
        public int StockAtDemandDate { get; set; }
        public string FreeText1 { get; set; }
        public string FreeText2 { get; set; }
        public string FreeText3 { get; set; }
        public string FreeText4 { get; set; }
        public string FreeText5 { get; set; }
        public Nullable<System.DateTime> ZaN_LastMod { get; set; }
    }
}
