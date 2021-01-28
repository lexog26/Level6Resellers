using Level6Resellers.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Level6Resellers.DataLayer.EntityConfigs
{
    public class ProductConfig
    {
        public ProductConfig(EntityTypeBuilder<Product> entity)
        {
            entity.ToTable("Products");
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Id).ValueGeneratedOnAdd();
            entity.Property(p => p.Name).IsRequired(false).HasMaxLength(50);
            entity.Property(p => p.Price).IsRequired(true);

            entity.Property(p => p.LastTimeStamp).IsRequired().ValueGeneratedOnAddOrUpdate();
            entity.Property(p => p.ModifiedDate).IsRequired(false).ValueGeneratedOnUpdate();
            entity.Property(p => p.CreatedDate).IsRequired().ValueGeneratedOnAdd();


            entity.HasMany(p => p.ProductResellerCustomers)
                .WithOne(r => r.Product);

        }
    }
}
