using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DAL.Model.BL;
using AutoMapper;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace DAL.Model
{
    public class DealerPartsMaster : IDBData
    {
    
      [Key]
      public int Id {set; get;}

      public DateTime? CreationDate { set; get; }
      public string File { set; get; }
      public string Status { get; set; }
      
      public string ItemCode { set; get; }
      public string WarehouseCode { set; get;}

      public string WarehouseGroupCode { set; get; }
      public DateTime? ExtractionDate  { set; get; }
      public string Description { set; get; }
      public string MasterItemCode { set; get; }
      public string PreferredSupplierCode { set; get; }

      public DateTime? ActivationDate { set; get; }
      public decimal? UnitCost { set; get; }
      public string UnitCostCurrency { set; get; }
      public string BuyerCode  { set; get; }
      public decimal? Weight { set; get; }
      public string WeightUnitOfMeasure { set; get; }

      public decimal? Volume { set; get; }
      public string VolumeUnitOfMeasure  { set; get; }
      public string UnitOfMeasure { set; get; }
      public int? PackSize { set; get; }
      public string Active { set; get; }
      public int? SetQuantity  { set; get; }
      public int? LeadTime { set; get; }

      public int? MinimumOrderQty { set; get; }
      public int? MultipleOrderQty { set; get; }
      public decimal? PurchasePrice  { set; get; }
      public string PurchasePriceCurrency  { set; get; }
      public int? CurrentStock { set; get; }
      public int? OutstandingOrderQuantity { set; get; }

      public int? TotalBackOrders { set; get; }
      public int? InTransitStock { set; get; }
      public int? ReservedStock  { set; get; }
      public string ReplacedItemCode { set; get; }
      public string InheritStock  { set; get; }
      public decimal? ReplacementMultiplier  { set; get; }
      public int? BulkOrderQuantity1 { set; get; }

      public int? BulkOrderQuantity2 { set; get; }

      public StringModel ToStringModel<BLModel, StringModel>()
      {
            Mapper.CreateMap<DealerPartsMaster, StringDealerPartsMaster>()
             .ForAllMembers(item => item.ToString().CutDownTo(50));

            var stringModel = Mapper.Map<DealerPartsMaster, StringDealerPartsMaster>(this);

            stringModel.ExtractionDate = ExtractionDate.DateTimeToString();
            stringModel.Description = Description.CutDownTo(100);

            stringModel.ActivationDate = ActivationDate.DateToString();
            stringModel.UnitCost = UnitCost.DecimalToString(2);
            stringModel.Weight = Weight.DecimalToString(4);

            stringModel.Volume = Volume.DecimalToString(4);
            stringModel.Active = Active.CutDownTo(1);

            stringModel.PurchasePrice = PurchasePrice.DecimalToString(2); 

            stringModel.InheritStock = InheritStock.CutDownTo(1);
            stringModel.ReplacementMultiplier = ReplacementMultiplier.DecimalToString(2); 
       
            Mapper.CreateMap<StringDealerPartsMaster, StringModel>();
            var stringModelRet = Mapper.Map<StringDealerPartsMaster, StringModel>(stringModel);


            return stringModelRet;

      }

    }

}
