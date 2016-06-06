using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class StringOrderExport : FileData
    {
        public string ItemCode { get; set; }
        public string WarehouseCode { get; set; }
        public string WarehouseGroupCode { get; set; }
        public string SupplierCode  { get; set; }
        public string UnitCost  { get; set; }
        public string UnitCostCurrencyCode  { get; set; }
        public string ExportDate { get; set; }

        public string ConfirmedOrderQuantity { get; set; }
        public string ItemDescription  { get; set; }
        public string TotalBackOrders { get; set; }
        public string OutstandingOrders  { get; set; }
        public string DemandType  { get; set; }
        public string BufferStock  { get; set; }
        public string LeadTime  { get; set; }
        public string RecommendedOrderQuantity { get; set; }
        public string PicksClass  { get; set; }
        public string VAUClass  { get; set; }
        public string FrequencyClass { get; set; }
        public string VolumeClass  { get; set; }
        public string EstimateOfDemand { get; set; }
        public string BuyerCode  { get; set; }
        public string Returnable { get; set; }
        public string Stocked { get; set; }
        public string Hazardous { get; set; }
        public string DueDate  { get; set; }
        public string ConfirmUserID { get; set; }

        public StringOrderExport()
        {
        }

        StringOrderExport(string line)
        {
            ReadFromLine(line);
        }

        public override string[] Verify()
        {
            throw new NotImplementedException();
        }
    }
}
