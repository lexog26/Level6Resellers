using Level6Resellers.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Level6Resellers.DataLayer.EntityConfigs
{
    public class ProductResellerCustomerConfig
    {
        public ProductResellerCustomerConfig(EntityTypeBuilder<ProductResellerCustomer> entity)
        {
            entity.ToTable("ProductResellerCustomers");
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Id).ValueGeneratedOnAdd();

            entity.Property(p => p.LastTimeStamp).IsRequired().ValueGeneratedOnAddOrUpdate();
            entity.Property(p => p.ModifiedDate).IsRequired(false).ValueGeneratedOnUpdate();
            entity.Property(p => p.CreatedDate).IsRequired().ValueGeneratedOnAdd();

            entity.HasOne(p => p.Product)
                .WithMany(p => p.ProductResellerCustomers)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(p => p.ResellerCompany)
                .WithMany(r => r.ProductResellerCustomers)
                .HasForeignKey(p => p.ResellerId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(p => p.CustomerCompany)
                .WithMany(c => c.ProductResellerCustomers)
                .HasForeignKey(p => p.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(p => p.ResellerCustomer)
                .WithMany(rc => rc.ProductResellerCustomers)
                .HasForeignKey(p => p.ResellerCustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(p => new { p.ProductId, p.ResellerCustomerId }).IsUnique(true);
        }
    }
}
