using DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class MigrationsContextFactory : IDbContextFactory<DBContext>
    {
        public DBContext Create()
        {
           var logDBCS=System.Configuration.ConfigurationManager.ConnectionStrings["log"].ConnectionString;
            return new DBContext(logDBCS);
        }
    }

    public class DBContext : DbContext
    {

        public DBContext(string connString) : base(connString) 
        {
        }

        public DbSet<DealerPartsMaster> DealerPartsMaster { get; set; }
        public DbSet<OpenPurchaseOrders> OpenPurchaseOrders { get; set; }
        public DbSet<OrderExport> OrderExport { get; set; }
        public DbSet<TransactionalDemand> TransactionalDemand { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure domain classes using modelBuilder here
/*
            modelBuilder.Entity<DealerPartsMaster>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("DealerPartsMaster");
            });

            modelBuilder.Entity<OpenPurchaseOrders>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("OpenPurchaseOrders");
            });

            modelBuilder.Entity<OrderExport>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("OrderExport");
            });

            modelBuilder.Entity<TransactionalDemand>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("TransactionalDemand");
            });

            #region DealerPartsMaster
            modelBuilder.Entity<DealerPartsMaster>().Property(p => p.ItemCode).HasColumnType("VARCHAR").HasMaxLength(50);
            modelBuilder.Entity<DealerPartsMaster>().Property(p => p.WarehouseCode).HasColumnType("VARCHAR").HasMaxLength(50);

            modelBuilder.Entity<DealerPartsMaster>().Property(p => p.WarehouseGroupCode).HasColumnType("VARCHAR").HasMaxLength(50);
            //modelBuilder.Entity<DealerPartsMaster>().Property(p => p.WarehouseCode).HasColumnType("VARCHAR").HasMaxLength(50); //ogranijdate !!!
            modelBuilder.Entity<DealerPartsMaster>().Property(p => p.Description).HasColumnType("VARCHAR").HasMaxLength(100); 
            modelBuilder.Entity<DealerPartsMaster>().Property(p => p.MasterItemCode).HasColumnType("VARCHAR").HasMaxLength(50);
            modelBuilder.Entity<DealerPartsMaster>().Property(p => p.PreferredSupplierCode).HasColumnType("VARCHAR").HasMaxLength(50);

            //  modelBuilder.Entity<DealerPartsMaster>().Property(p => p.ActivationDate).HasColumnType("VARCHAR").HasMaxLength(50); //ogranij date !
            modelBuilder.Entity<DealerPartsMaster>().Property(p => p.UnitCost).HasColumnType("DECIMAL").HasPrecision(14, 2);
            modelBuilder.Entity<DealerPartsMaster>().Property(p => p.UnitCostCurrency).HasColumnType("VARCHAR").HasMaxLength(50);
            modelBuilder.Entity<DealerPartsMaster>().Property(p => p.BuyerCode).HasColumnType("VARCHAR").HasMaxLength(50);
            modelBuilder.Entity<DealerPartsMaster>().Property(p => p.Weight).HasColumnType("DECIMAL").HasPrecision(14,4);
            modelBuilder.Entity<DealerPartsMaster>().Property(p => p.WeightUnitOfMeasure).HasColumnType("VARCHAR").HasMaxLength(50);

            modelBuilder.Entity<DealerPartsMaster>().Property(p => p.Volume).HasColumnType("DECIMAL").HasPrecision(14,4);
            modelBuilder.Entity<DealerPartsMaster>().Property(p => p.VolumeUnitOfMeasure).HasColumnType("VARCHAR").HasMaxLength(50);
            modelBuilder.Entity<DealerPartsMaster>().Property(p => p.UnitOfMeasure).HasColumnType("VARCHAR").HasMaxLength(50);
            //packsize
            modelBuilder.Entity<DealerPartsMaster>().Property(p => p.Active).HasColumnType("VARCHAR").HasMaxLength(1);
            //setquantity
            //loadtime

            //Minimum order qty
            //Multiple order qty 
            modelBuilder.Entity<DealerPartsMaster>().Property(p => p.PurchasePrice).HasColumnType("DECIMAL").HasPrecision(14, 2);
            modelBuilder.Entity<DealerPartsMaster>().Property(p => p.PurchasePriceCurrency).HasColumnType("VARCHAR").HasMaxLength(1);
            //Current stock 
            // Outstanding order quantity 

            //Total back orders 
            //In-transit stock 
            //Reserved stock 
            modelBuilder.Entity<DealerPartsMaster>().Property(p => p.ReplacedItemCode).HasColumnType("VARCHAR").HasMaxLength(50);
            modelBuilder.Entity<DealerPartsMaster>().Property(p => p.InheritStock).HasColumnType("Char").HasMaxLength(1);
            modelBuilder.Entity<DealerPartsMaster>().Property(p => p.ReplacementMultiplier).HasColumnType("DECIMAL").HasPrecision(14, 4);
            #endregion

            #region OpenPurchaseOrders
            modelBuilder.Entity<OpenPurchaseOrders>().Property(p => p.RowTransactionType).HasColumnType("Char").HasMaxLength(1);

            modelBuilder.Entity<OpenPurchaseOrders>().Property(p => p.ItemCode).HasColumnType("Char").HasMaxLength(1);
            modelBuilder.Entity<OpenPurchaseOrders>().Property(p => p.WarehouseCode).HasColumnType("VARCHAR").HasMaxLength(50);
            modelBuilder.Entity<OpenPurchaseOrders>().Property(p => p.WarehouseGroupCode).HasColumnType("VARCHAR").HasMaxLength(50);
            modelBuilder.Entity<OpenPurchaseOrders>().Property(p => p.OrderNumber).HasColumnType("VARCHAR").HasMaxLength(50);
            modelBuilder.Entity<OpenPurchaseOrders>().Property(p => p.OrderLineNumber).HasColumnType("VARCHAR").HasMaxLength(50);
            //modelBuilder.Entity<OpenPurchaseOrders>().Property(p => p.ExtractionDate).HasColumnType("VARCHAR").HasMaxLength(50);
            modelBuilder.Entity<OpenPurchaseOrders>().Property(p => p.SupplierCode).HasColumnType("VARCHAR").HasMaxLength(50);
            //modelBuilder.Entity<OpenPurchaseOrders>().Property(p => p.OrderQuantity).HasColumnType("VARCHAR").HasMaxLength(50);
            //modelBuilder.Entity<OpenPurchaseOrders>().Property(p => p.OrderDate).HasColumnType("VARCHAR").HasMaxLength(50);

            //modelBuilder.Entity<OpenPurchaseOrders>().Property(p => p.RequestedDate).HasColumnType("Char").HasMaxLength(1);
            //modelBuilder.Entity<OpenPurchaseOrders>().Property(p => p.ReceivedQuantity).HasColumnType("VARCHAR").HasMaxLength(50);
            //modelBuilder.Entity<OpenPurchaseOrders>().Property(p => p.ReceivedDate).HasColumnType("VARCHAR").HasMaxLength(50);
            modelBuilder.Entity<OpenPurchaseOrders>().Property(p => p.FreeText1).HasColumnType("VARCHAR").HasMaxLength(100);
            modelBuilder.Entity<OpenPurchaseOrders>().Property(p => p.FreeText2).HasColumnType("VARCHAR").HasMaxLength(100);
            modelBuilder.Entity<OpenPurchaseOrders>().Property(p => p.FreeText3).HasColumnType("VARCHAR").HasMaxLength(100);
            modelBuilder.Entity<OpenPurchaseOrders>().Property(p => p.FreeText4).HasColumnType("VARCHAR").HasMaxLength(100);
            modelBuilder.Entity<OpenPurchaseOrders>().Property(p => p.FreeText5).HasColumnType("VARCHAR").HasMaxLength(100);


            #endregion

            #region OrderExport
            modelBuilder.Entity<OrderExport>().Property(p => p.ItemCode).HasColumnType("VARCHAR").HasMaxLength(50);
            modelBuilder.Entity<OrderExport>().Property(p => p.WarehouseCode).HasColumnType("VARCHAR").HasMaxLength(50);
            modelBuilder.Entity<OrderExport>().Property(p => p.WarehouseGroupCode).HasColumnType("VARCHAR").HasMaxLength(50);
            modelBuilder.Entity<OrderExport>().Property(p => p.SupplierCode).HasColumnType("VARCHAR").HasMaxLength(50);
            modelBuilder.Entity<OrderExport>().Property(p => p.UnitCost).HasColumnType("DECIMAL").HasPrecision(14,2);
            modelBuilder.Entity<OrderExport>().Property(p => p.UnitCostCurrencyCode).HasColumnType("VARCHAR").HasMaxLength(50);
            //modelBuilder.Entity<OrderExport>().Property(p => p.ExportDate).HasColumnType("VARCHAR").HasMaxLength(50);

            //modelBuilder.Entity<OrderExport>().Property(p => p.ConfirmedOrderQuantity).HasColumnType("VARCHAR").HasMaxLength(50);
            modelBuilder.Entity<OrderExport>().Property(p => p.ItemDescription).HasColumnType("VARCHAR").HasMaxLength(100);
            //modelBuilder.Entity<OrderExport>().Property(p => p.TotalBackOrders).HasColumnType("VARCHAR").HasMaxLength(50);
            //modelBuilder.Entity<OrderExport>().Property(p => p.OutstandingOrders).HasColumnType("VARCHAR").HasMaxLength(50);
            modelBuilder.Entity<OrderExport>().Property(p => p.DemandType).HasColumnType("VARCHAR").HasMaxLength(50);
            //modelBuilder.Entity<OrderExport>().Property(p => p.BufferStock).HasColumnType("VARCHAR").HasMaxLength(50);
            modelBuilder.Entity<OrderExport>().Property(p => p.LeadTime).HasColumnType("DECIMAL").HasPrecision(14,2);//HasMaxLength(50);
            //modelBuilder.Entity<OrderExport>().Property(p => p.RecommendedOrderQuantity).HasColumnType("VARCHAR").HasMaxLength(50);
            modelBuilder.Entity<OrderExport>().Property(p => p.PicksClass).HasColumnType("VARCHAR").HasMaxLength(50);
            modelBuilder.Entity<OrderExport>().Property(p => p.VAUClass).HasColumnType("VARCHAR").HasMaxLength(50);
            modelBuilder.Entity<OrderExport>().Property(p => p.FrequencyClass).HasColumnType("VARCHAR").HasMaxLength(50);
            modelBuilder.Entity<OrderExport>().Property(p => p.VolumeClass).HasColumnType("VARCHAR").HasMaxLength(50);
            modelBuilder.Entity<OrderExport>().Property(p => p.EstimateOfDemand).HasColumnType("DECIMAL").HasPrecision(14,2);
            modelBuilder.Entity<OrderExport>().Property(p => p.BuyerCode).HasColumnType("VARCHAR").HasMaxLength(50);
            modelBuilder.Entity<OrderExport>().Property(p => p.Returnable).HasColumnType("CHAR").HasMaxLength(1);
            modelBuilder.Entity<OrderExport>().Property(p => p.Stocked).HasColumnType("CHAR").HasMaxLength(1);
            modelBuilder.Entity<OrderExport>().Property(p => p.Hazardous).HasColumnType("CHAR").HasMaxLength(1);
            //modelBuilder.Entity<OrderExport>().Property(p => p.DueDate).HasColumnType("VARCHAR").HasMaxLength(50);
            modelBuilder.Entity<OrderExport>().Property(p => p.ConfirmUserID).HasColumnType("VARCHAR").HasMaxLength(50);
            #endregion

            #region TransactionalDemand
            modelBuilder.Entity<TransactionalDemand>().Property(p => p.RowTransactionType).HasColumnType("CHAR").HasMaxLength(1);
            modelBuilder.Entity<TransactionalDemand>().Property(p => p.ItemCode).HasColumnType("VARCHAR").HasMaxLength(50);
            modelBuilder.Entity<TransactionalDemand>().Property(p => p.WarehouseCode).HasColumnType("VARCHAR").HasMaxLength(50);
            modelBuilder.Entity<TransactionalDemand>().Property(p => p.WarehouseGroupCode).HasColumnType("VARCHAR").HasMaxLength(50);
            modelBuilder.Entity<TransactionalDemand>().Property(p => p.SalesOrderNumber).HasColumnType("VARCHAR").HasMaxLength(50);
            modelBuilder.Entity<TransactionalDemand>().Property(p => p.SalesOrderLineNumber).HasColumnType("VARCHAR").HasMaxLength(50);
            //modelBuilder.Entity<TransactionalDemand>().Property(p => p.ExtractionDate).HasColumnType("VARCHAR").HasMaxLength(50);
            //modelBuilder.Entity<TransactionalDemand>().Property(p => p.OrderedRequestedQuantity).HasColumnType("VARCHAR").HasMaxLength(50);
            //modelBuilder.Entity<TransactionalDemand>().Property(p => p.DeliveredSuppliedQuantity).HasColumnType("VARCHAR").HasMaxLength(50);
            //modelBuilder.Entity<TransactionalDemand>().Property(p => p.DemandDate).HasColumnType("VARCHAR").HasMaxLength(50);

            modelBuilder.Entity<TransactionalDemand>().Property(p => p.CustomerCode).HasColumnType("VARCHAR").HasMaxLength(50);
            modelBuilder.Entity<TransactionalDemand>().Property(p => p.UseForForecasting).HasColumnType("VARCHAR").HasMaxLength(1);
            modelBuilder.Entity<TransactionalDemand>().Property(p => p.UseForServiceLevel).HasColumnType("VARCHAR").HasMaxLength(1);
            modelBuilder.Entity<TransactionalDemand>().Property(p => p.UseForClassification).HasColumnType("VARCHAR").HasMaxLength(1);
            //modelBuilder.Entity<TransactionalDemand>().Property(p => p.StockAtDemandDate).HasColumnType("VARCHAR").HasMaxLength(1);
            modelBuilder.Entity<TransactionalDemand>().Property(p => p.FreeText1).HasColumnType("VARCHAR").HasMaxLength(100);
            modelBuilder.Entity<TransactionalDemand>().Property(p => p.FreeText2).HasColumnType("VARCHAR").HasMaxLength(100);
            modelBuilder.Entity<TransactionalDemand>().Property(p => p.FreeText3).HasColumnType("VARCHAR").HasMaxLength(100);
            modelBuilder.Entity<TransactionalDemand>().Property(p => p.FreeText4).HasColumnType("VARCHAR").HasMaxLength(100);
            modelBuilder.Entity<TransactionalDemand>().Property(p => p.FreeText5).HasColumnType("VARCHAR").HasMaxLength(100);
            #endregion

    */
            base.OnModelCreating(modelBuilder);
        }
    }

}
