﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnboardInternship
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    public partial class InternshipEntities : DbContext
    {
        public InternshipEntities()
            : base("name=InternshipEntities")
        {
            Configuration.ProxyCreationEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Store> Stores { get; set; }

        public System.Data.Entity.DbSet<OnboardInternship.Models.ProductModel> ProductModels { get; set; }

        public System.Data.Entity.DbSet<OnboardInternship.Models.StoreModel> StoreModels { get; set; }

        public System.Data.Entity.DbSet<OnboardInternship.Models.SalesModel> SalesModels { get; set; }
        public IQueryable<Product> Product { get; internal set; }
    }
}
