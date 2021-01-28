using Level6Resellers.Domain.Companies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Level6Resellers.DataLayer.EntityConfigs
{
    public class CustomerCompanyConfig
    {
        public CustomerCompanyConfig(EntityTypeBuilder<CustomerCompany> entity)
        {
            entity.ToTable("CustomerCompanies");
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Name).IsRequired(false).HasMaxLength(50);

            entity.Property(p => p.LastTimeStamp).IsRequired().ValueGeneratedOnAddOrUpdate();
            entity.Property(p => p.ModifiedDate).IsRequired(false).ValueGeneratedOnUpdate();
            entity.Property(p => p.CreatedDate).IsRequired().ValueGeneratedOnAdd();

            entity.HasMany(p => p.Users)
                .WithOne(u => u.CustomerCompany);

            entity.HasMany(p => p.ResellerCustomers)
                .WithOne(r => r.CustomerCompany);

            entity.HasMany(p => p.ProductResellerCustomers)
                .WithOne(p => p.CustomerCompany);

            entity.HasMany(p => p.Purchases)
                .WithOne(p => p.CustomerCompany);
        }
    }
}
