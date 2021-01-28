using Level6Resellers.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Level6Resellers.DataLayer.EntityConfigs
{
    public class UserCustomerConfig
    {
        public UserCustomerConfig(EntityTypeBuilder<UserCustomer> entity)
        {
            entity.ToTable("UserCustomers");
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Id).ValueGeneratedOnAdd();
            entity.Property(p => p.Name).IsRequired(false).HasMaxLength(50);
            entity.Property(p => p.Dni).IsRequired(true).HasMaxLength(30);
            entity.Property(p => p.LastName).IsRequired(false).HasMaxLength(100);

            entity.Property(p => p.LastTimeStamp).IsRequired().ValueGeneratedOnAddOrUpdate();
            entity.Property(p => p.ModifiedDate).IsRequired(false).ValueGeneratedOnUpdate();
            entity.Property(p => p.CreatedDate).IsRequired().ValueGeneratedOnAdd();

            entity.HasOne(p => p.CustomerCompany)
                .WithMany(c => c.Users)
                .HasForeignKey(p => p.CustomerCompanyId);

            entity.HasMany(p => p.Purchases)
                .WithOne(p => p.UserCustomer);
        }
    }
}
