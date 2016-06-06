using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Model
{
    public class BLDealerPartsMaster 
    {
        public string ItemCode { set; get; }
        public string WarehouseCode { set; get; }

        public string WarehouseGroupCode { set; get; }
        public DateTime ExtractionDate { set; get; }
        public string Description { set; get; }
        public string MasterItemCode { set; get; }
        public string PreferredSupplierCode { set; get; }

        public DateTime ActivationDate { set; get; }
        public decimal UnitCost { set; get; }
        public string UnitCostCurrency { set; get; }
        public string BuyerCode { set; get; }
        public decimal Weight { set; get; }
        public string WeightUnitOfMeasure { set; get; }

        public decimal Volume { set; get; }
        public string VolumeUnitOfMeasure { set; get; }
        public string UnitOfMeasure { set; get; }
        public int PackSize { set; get; }
        public string Active { set; get; }
        public int SetQuantity { set; get; }
        public int LeadTime { set; get; }

        public string MinimumOrderQty { set; get; }
        public string MultipleOrderQty { set; get; }
        public decimal PurchasePrice { set; get; }
        public string PurchasePriceCurrency { set; get; }
        public int CurrentStock { set; get; }
        public int OutstandingOrderQuantity { set; get; }

        public int TotalBackOrders { set; get; }
        public int InTransitStock { set; get; }
        public int ReservedStock { set; get; }
        public string ReplacedItemCode { set; get; }
        public string InheritStock { set; get; }
        public decimal ReplacementMultiplier { set; get; }

       
    }



}
