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
    public class TransactionalDemand : IDBData
    {


        [Key]
        public int Id { set; get; }

        public DateTime? CreationDate { set; get; }
        public string File { set; get; }
        public string Status { get; set; }

        public string RowTransactionType { set; get; }
        public string ItemCode  { set; get; }
        public string WarehouseCode { set; get; }
        public string WarehouseGroupCode { set; get; }
        public string SalesOrderNumber { set; get; }
        public string SalesOrderLineNumber { set; get; }

        public DateTime? ExtractionDate { set; get; }
        public int? OrderedRequestedQuantity { set; get; }
        public int? DeliveredSuppliedQuantity { set; get; }
        public DateTime? DemandDate { set; get; }

        public string CustomerCode  { set; get; }
        public string UseForForecasting { set; get; }
        public string UseForServiceLevel { set; get; }
        public string UseForClassification { set; get; }
        public int? StockAtDemandDate  { set; get; }
        public string FreeText1 { set; get; }
        public string FreeText2 { set; get; }

        public string FreeText3 { set; get; }
        public string FreeText4 { set; get; }
        public string FreeText5 { set; get; }

        public StringModel ToStringModel<BLModel, StringModel>()
        {
            Mapper.CreateMap<TransactionalDemand, StringTransactionalDemand>()
             .ForAllMembers(item => item.ToString().CutDownTo(50));

            var stringModel = Mapper.Map<TransactionalDemand, StringTransactionalDemand>(this);

            stringModel.RowTransactionType = RowTransactionType.CutDownTo(1);

            stringModel.ExtractionDate = ExtractionDate.DateTimeToString();
            stringModel.DemandDate = DemandDate.DateToString();

            stringModel.UseForForecasting = UseForForecasting.CutDownTo(1);
            stringModel.UseForServiceLevel = UseForServiceLevel.CutDownTo(1);
            stringModel.UseForClassification = UseForClassification.CutDownTo(1);
            stringModel.FreeText1 = FreeText1.CutDownTo(100);

            stringModel.FreeText2 = FreeText2.CutDownTo(100);
            stringModel.FreeText3 = FreeText3.CutDownTo(100);
            stringModel.FreeText4 = FreeText4.CutDownTo(100);

            Mapper.CreateMap<StringTransactionalDemand, StringModel>();
            var stringModelRet = Mapper.Map<StringTransactionalDemand, StringModel>(stringModel);


            return stringModelRet;

        }

    }
}
