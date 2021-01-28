using Level6Resellers.Domain.Companies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Level6Resellers.DataLayer.EntityConfigs
{
    public class ResellerCompanyConfig
    {
        public ResellerCompanyConfig(EntityTypeBuilder<ResellerCompany> entity)
        {
            entity.ToTable("ResellerCompanies");
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Id).ValueGeneratedOnAdd();
            entity.Property(p => p.Name).IsRequired(false).HasMaxLength(50);

            entity.Property(p => p.LastTimeStamp).IsRequired().ValueGeneratedOnAddOrUpdate();
            entity.Property(p => p.ModifiedDate).IsRequired(false).ValueGeneratedOnUpdate();
            entity.Property(p => p.CreatedDate).IsRequired().ValueGeneratedOnAdd();

            entity.HasMany(p => p.ResellerCustomers)
                .WithOne(r => r.ResellerCompany);
                
                
        }
    }
}
