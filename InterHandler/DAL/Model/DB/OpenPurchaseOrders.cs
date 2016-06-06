using AutoMapper;
using DAL.Model.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class OpenPurchaseOrders : IDBData
    {


        [Key]
        public int Id { set; get; }

        public DateTime? CreationDate { set; get; }
        public string File { set; get; }
        public string Status { get; set; }


        public string RowTransactionType { get; set; }

        public string ItemCode { get; set; }
        public string WarehouseCode { get; set; }
        public string WarehouseGroupCode { get; set; }
        public string OrderNumber { get; set; }
        public string OrderLineNumber { get; set; }
        public DateTime? ExtractionDate  { get; set; }
        public string SupplierCode  { get; set; }
        public int? OrderQuantity  { get; set; }
        public DateTime? OrderDate  { get; set; }

        public DateTime? RequestedDate { get; set; }
        public int? ReceivedQuantity  { get; set; }
        public DateTime? ReceivedDate  { get; set; }
        public string FreeText1 { get; set; }
        public string FreeText2 { get; set; }
        public string FreeText3 { get; set; }
        public string FreeText4 { get; set; }
        public string FreeText5 { get; set; }

        public StringModel ToStringModel<BLModel, StringModel>()
        {
            Mapper.CreateMap<OpenPurchaseOrders, StringOpenPurchaseOrders>()
             .ForAllMembers(item => item.ToString().CutDownTo(50));

            var stringModel = Mapper.Map<OpenPurchaseOrders, StringOpenPurchaseOrders>(this);

            stringModel.RowTransactionType = RowTransactionType.CutDownTo(1);

            stringModel.ExtractionDate = ExtractionDate.DateTimeToString();
            stringModel.OrderDate = OrderDate.DateToString();

            stringModel.RequestedDate = RequestedDate.DateToString();
            stringModel.ReceivedDate = ReceivedDate.DateToString();

            stringModel.FreeText1 = FreeText1.CutDownTo(100);
            stringModel.FreeText2 = FreeText2.CutDownTo(100);
            stringModel.FreeText3 = FreeText3.CutDownTo(100);
            stringModel.FreeText4 = FreeText4.CutDownTo(100);


            Mapper.CreateMap<StringDealerPartsMaster, StringModel>();
            var stringModelRet = Mapper.Map<StringOpenPurchaseOrders, StringModel>(stringModel);


            return stringModelRet;

        }

    }
}
