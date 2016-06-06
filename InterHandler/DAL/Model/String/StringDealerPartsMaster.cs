using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class StringDealerPartsMaster : FileData
    {
      public string ItemCode { set; get; }
      public string WarehouseCode { set; get;}

      public string WarehouseGroupCode { set; get; }
      public string ExtractionDate  { set; get; }
      public string Description { set; get; }
      public string MasterItemCode { set; get; }
      public string PreferredSupplierCode { set; get; }

      public string ActivationDate { set; get; }
      public string UnitCost { set; get; }
      public string UnitCostCurrency { set; get; }
      public string BuyerCode  { set; get; }
      public string Weight { set; get; }
      public string WeightUnitOfMeasure { set; get; }

      public string Volume { set; get; }
      public string VolumeUnitOfMeasure  { set; get; }
      public string UnitOfMeasure { set; get; }
      public string PackSize { set; get; }
      public string Active { set; get; }
      public string SetQuantity  { set; get; }
      public string LeadTime { set; get; }

      public string MinimumOrderQty { set; get; }
      public string MultipleOrderQty { set; get; }
      public string PurchasePrice  { set; get; }
      public string PurchasePriceCurrency  { set; get; }
      public string CurrentStock { set; get; }
      public string OutstandingOrderQuantity { set; get; }

      public string TotalBackOrders { set; get; }
      public string InTransitStock { set; get; }
      public string ReservedStock  { set; get; }
      public string ReplacedItemCode { set; get; }
      public string InheritStock  { set; get; }
      public string ReplacementMultiplier  { set; get; }
      public string BulkOrderQuantity1 { set; get; }

      public string BulkOrderQuantity2 { set; get; }

        public StringDealerPartsMaster()
      {
        
      }

      public StringDealerPartsMaster(string line)
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
          return string.Format("DealerPartsMaster_FULL_{0}.txt", timeStamp);
      }
    }

}
