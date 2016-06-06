using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Model
{
    public class BLOrderExport 
    {
        public int Id { get; set; }

        public string ItemCode { get; set; }
        public string WarehouseCode { get; set; }
        public string WarehouseGroupCode { get; set; }
        public string SupplierCode { get; set; }
        public decimal UnitCost { get; set; }
        public string UnitCostCurrencyCode { get; set; }
        public DateTime ExportDate { get; set; }

        public int ConfirmedOrderQuantity { get; set; }
        public string ItemDescription { get; set; }
        public int TotalBackOrders { get; set; }
        public int OutstandingOrders { get; set; }
        public string DemandType { get; set; }
        public int BufferStock { get; set; }
        public decimal LeadTime { get; set; }
        public int RecommendedOrderQuantity { get; set; }
        public string PicksClass { get; set; }
        public string VAUClass { get; set; }
        public string FrequencyClass { get; set; }
        public string VolumeClass { get; set; }
        public decimal EstimateOfDemand { get; set; }
        public string BuyerCode { get; set; }
        public string Returnable { get; set; }
        public string Stocked { get; set; }
        public string Hazardous { get; set; }
        public DateTime DueDate { get; set; }
        public string ConfirmUserID { get; set; }
    }
}
