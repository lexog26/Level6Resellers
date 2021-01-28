using Level6Resellers.DataLayer.EntityConfigs;
using Level6Resellers.Domain.Companies;
using Level6Resellers.Domain.Products;
using Level6Resellers.Domain.Purchases;
using Level6Resellers.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Level6Resellers.DataLayer.Context
{
    public partial class ResellersContext : DbContext
    {
        public ResellersContext(DbContextOptions<ResellersContext> options) : base(options)
        { }

        public ResellersContext() : base()
        { }

        #region DbSets

        public DbSet<CustomerCompany> CustomerCompanies { get; set; }

        public DbSet<ResellerCompany> ResellerCompanies { get; set; }

        public DbSet<ResellerCustomer> ResellerCustomerCompanies { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductResellerCustomer> ProductResellerCustomers { get; set; }

        public DbSet<UserCustomer> UserCustomers { get; set; }

        public DbSet<Purchase> Purchases { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            new CustomerCompanyConfig(builder.Entity<CustomerCompany>());
            new ResellerCompanyConfig(builder.Entity<ResellerCompany>());
            new ResellerCustomerConfig(builder.Entity<ResellerCustomer>());
            new ProductConfig(builder.Entity<Product>());
            new ProductResellerCustomerConfig(builder.Entity<ProductResellerCustomer>());
            new UserCustomerConfig(builder.Entity<UserCustomer>());
            new PurchaseConfig(builder.Entity<Purchase>());
        }
    }
}
