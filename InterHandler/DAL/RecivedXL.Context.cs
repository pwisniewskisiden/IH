﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class CDNXL : DbContext
    {
        public CDNXL()
            : base("name=CDNXL")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        [DbFunction("CDNXL", "Siden_Dealer_Parts_Master")]
        public virtual IQueryable<Siden_Dealer_Parts_Master_Result> Siden_Dealer_Parts_Master()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<Siden_Dealer_Parts_Master_Result>("[CDNXL].[Siden_Dealer_Parts_Master]()");
        }
    
        [DbFunction("CDNXL", "Siden_Open_Purchase_Orders")]
        public virtual IQueryable<Siden_Open_Purchase_Orders_Result> Siden_Open_Purchase_Orders()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<Siden_Open_Purchase_Orders_Result>("[CDNXL].[Siden_Open_Purchase_Orders]()");
        }
    
        [DbFunction("CDNXL", "Siden_Transactional_Demand")]
        public virtual IQueryable<Siden_Transactional_Demand_Result> Siden_Transactional_Demand()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<Siden_Transactional_Demand_Result>("[CDNXL].[Siden_Transactional_Demand]()");
        }
    }
}
