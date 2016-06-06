using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class OrderExport
    {
    
        [Key]
        public int Id { set; get; }

        public DateTime? CreationDate { set; get; }
        public string File { set; get; }
        public string Status { get; set; }


        public string ItemCode { get; set; }
        public string WarehouseCode { get; set; }
        public string WarehouseGroupCode { get; set; }
        public string SupplierCode  { get; set; }
        public decimal? UnitCost  { get; set; }
        public string UnitCostCurrencyCode  { get; set; }
        public DateTime? ExportDate { get; set; }

        public int? ConfirmedOrderQuantity { get; set; }
        public string ItemDescription  { get; set; }
        public int? TotalBackOrders { get; set; }
        public int? OutstandingOrders  { get; set; }
        public string DemandType  { get; set; }
        public int? BufferStock  { get; set; }
        public decimal? LeadTime  { get; set; }
        public int? RecommendedOrderQuantity { get; set; }
        public string PicksClass  { get; set; }
        public string VAUClass  { get; set; }
        public string FrequencyClass { get; set; }
        public string VolumeClass  { get; set; }
        public decimal? EstimateOfDemand { get; set; }
        public string BuyerCode  { get; set; }
        public string Returnable { get; set; }
        public string Stocked { get; set; }
        public string Hazardous { get; set; }
        public DateTime? DueDate  { get; set; }
        public string ConfirmUserID { get; set; }

        public OrderExport()
        {

        }

        public OrderExport(StringOrderExport stringModel)
        {
             var typeRet = typeof(OrderExport);
            var propertiesRet = typeRet.GetProperties();

            var typeSource = typeof(StringOrderExport);
            var propertiesSource = typeSource.GetProperties();

           
            foreach (PropertyInfo propertySource in propertiesSource)
            {
                foreach (PropertyInfo propertyRet in propertiesRet)
                {
                    if (propertySource.Name != propertyRet.Name) continue;
                    

                    if (propertyRet.PropertyType.Name == "String")
                    {
                        try
                        {
                            propertyRet.SetValue(this, propertySource.GetValue(stringModel, null), null);
                        }
                        catch { }
                        continue;
                    }

                    if (propertyRet.PropertyType.Name == "Int32")
                    {
                        try
                        {
                            var ToSet = propertySource.GetValue(stringModel, null).ToString();
                            propertyRet.SetValue(this, Int32.Parse(ToSet), null);
                        }
                        catch { }
                        continue;
                    }

                    if (propertyRet.PropertyType.Name == "Decimal")
                    {
                        try
                        {
                            var ToSet = propertySource.GetValue(stringModel, null).ToString();
                            propertyRet.SetValue(this, Decimal.Parse(ToSet), null);
                        }
                        catch { }
                        continue;
                    }

                    if (propertyRet.PropertyType.Name == "DateTime")
                    {
                        try
                        {
                            var ToSet = propertySource.GetValue(stringModel, null).ToString();
                            propertyRet.SetValue(this, DateTime.Parse(ToSet), null);
                        }
                        catch { }
                        continue;
                    }


                    /*
                    var deb1 = property.PropertyType.Name;
                    var deb2 = property.GetType();
                    var deb3 = property.GetType().Name;

                    if (property.PropertyType.Name == "String") { property.SetValue(toAdd, line + " " + property.Name, null); continue; }
                    if (property.PropertyType.Name == "Int32") { property.SetValue(toAdd, i, null); i++; continue; }
                    if (property.PropertyType.Name == "DateTime") { property.SetValue(toAdd, DateTime.Now, null); continue; }
                    if (property.PropertyType.Name == "Decimal") { property.SetValue(toAdd, 1.111111111111111111M, null); continue; }
                    */
                }
            }
         


        }

        public StringModel ToStringModel<BLModel, StringModel>()
        {
            Mapper.CreateMap<OrderExport, StringOrderExport>()
             .ForAllMembers(item => item.ToString().CutDownTo(50));

            var stringModel = Mapper.Map<OrderExport, StringOrderExport>(this);

            stringModel.UnitCost = UnitCost.DecimalToString(2); 
            stringModel.ExportDate = ExportDate.DateTimeToString();

            stringModel.ItemDescription = ItemDescription.CutDownTo(50);
            stringModel.LeadTime = LeadTime.DecimalToString(2);
            stringModel.EstimateOfDemand = EstimateOfDemand.DecimalToString(2);

            stringModel.Returnable = Returnable.CutDownTo(1);
            stringModel.Stocked = Stocked.CutDownTo(1);
            stringModel.Hazardous = Hazardous.CutDownTo(1);
            stringModel.DueDate = DueDate.DateTimeToString();


            Mapper.CreateMap<StringOrderExport, StringModel>();
            var stringModelRet = Mapper.Map<StringOrderExport, StringModel>(stringModel);


            return stringModelRet;

        }


    }
}
