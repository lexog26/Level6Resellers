using Level6Resellers.Domain.Companies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Level6Resellers.DataLayer.EntityConfigs
{
    public class ResellerCustomerConfig
    {
        public ResellerCustomerConfig(EntityTypeBuilder<ResellerCustomer> entity)
        {
            entity.ToTable("ResellerCustomer");
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Id).ValueGeneratedOnAdd();

            entity.Property(p => p.LastTimeStamp).IsRequired().ValueGeneratedOnAddOrUpdate();
            entity.Property(p => p.ModifiedDate).IsRequired(false).ValueGeneratedOnUpdate();
            entity.Property(p => p.CreatedDate).IsRequired().ValueGeneratedOnAdd();

            entity.HasOne(p => p.CustomerCompany)
                .WithMany(c => c.ResellerCustomers)
                .HasForeignKey(p => p.CustomerCompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(p => p.ResellerCompany)
                .WithMany(r => r.ResellerCustomers)
                .HasForeignKey(p => p.ResellerCompanyId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
