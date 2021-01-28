using Level6Resellers.Domain.Purchases;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Level6Resellers.DataLayer.EntityConfigs
{
    public class PurchaseConfig
    {
        public PurchaseConfig(EntityTypeBuilder<Purchase> entity)
        {
            entity.ToTable("Purchases");
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Id).ValueGeneratedOnAdd();

            entity.Property(p => p.LastTimeStamp).IsRequired().ValueGeneratedOnAddOrUpdate();
            entity.Property(p => p.ModifiedDate).IsRequired(false).ValueGeneratedOnUpdate();
            entity.Property(p => p.CreatedDate).IsRequired().ValueGeneratedOnAdd();

            entity.HasOne(p => p.Product)
                .WithMany(p => p.Purchases)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(p => p.ResellerCompany)
                .WithMany(r => r.Purchases)
                .HasForeignKey(p => p.ResellerId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(p => p.CustomerCompany)
                .WithMany(c => c.Purchases)
                .HasForeignKey(p => p.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(p => p.UserCustomer)
                .WithMany(u => u.Purchases)
                .HasForeignKey(p => p.UserCustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(p => p.ProductResellerCustomer)
                .WithMany(prc => prc.Purchases)
                .HasForeignKey(p => p.ProductResellerCustomerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
