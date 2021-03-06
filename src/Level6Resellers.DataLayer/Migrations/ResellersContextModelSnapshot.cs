﻿// <auto-generated />
using System;
using Level6Resellers.DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Level6Resellers.DataLayer.Migrations
{
    [DbContext(typeof(ResellersContext))]
    partial class ResellersContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Level6Resellers.Domain.Companies.CustomerCompany", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastTimeStamp")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("CustomerCompanies");
                });

            modelBuilder.Entity("Level6Resellers.Domain.Companies.ResellerCompany", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastTimeStamp")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("ResellerCompanies");
                });

            modelBuilder.Entity("Level6Resellers.Domain.Companies.ResellerCustomer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerCompanyId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("LastTimeStamp")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2");

                    b.Property<int>("ResellerCompanyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerCompanyId");

                    b.HasIndex("ResellerCompanyId");

                    b.ToTable("ResellerCustomer");
                });

            modelBuilder.Entity("Level6Resellers.Domain.Products.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastTimeStamp")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Level6Resellers.Domain.Products.ProductResellerCustomer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("LastTimeStamp")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ResellerCustomerId")
                        .HasColumnType("int");

                    b.Property<int>("ResellerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ResellerCustomerId");

                    b.HasIndex("ResellerId");

                    b.HasIndex("ProductId", "ResellerCustomerId")
                        .IsUnique();

                    b.ToTable("ProductResellerCustomers");
                });

            modelBuilder.Entity("Level6Resellers.Domain.Purchases.Purchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("LastTimeStamp")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ProductResellerCustomerId")
                        .HasColumnType("int");

                    b.Property<int>("ResellerId")
                        .HasColumnType("int");

                    b.Property<int>("UserCustomerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.HasIndex("ProductResellerCustomerId");

                    b.HasIndex("ResellerId");

                    b.HasIndex("UserCustomerId");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("Level6Resellers.Domain.Users.UserCustomer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerCompanyId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Dni")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("LastTimeStamp")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("CustomerCompanyId");

                    b.ToTable("UserCustomers");
                });

            modelBuilder.Entity("Level6Resellers.Domain.Companies.ResellerCustomer", b =>
                {
                    b.HasOne("Level6Resellers.Domain.Companies.CustomerCompany", "CustomerCompany")
                        .WithMany("ResellerCustomers")
                        .HasForeignKey("CustomerCompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Level6Resellers.Domain.Companies.ResellerCompany", "ResellerCompany")
                        .WithMany("ResellerCustomers")
                        .HasForeignKey("ResellerCompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Level6Resellers.Domain.Products.ProductResellerCustomer", b =>
                {
                    b.HasOne("Level6Resellers.Domain.Companies.CustomerCompany", "CustomerCompany")
                        .WithMany("ProductResellerCustomers")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Level6Resellers.Domain.Products.Product", "Product")
                        .WithMany("ProductResellerCustomers")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Level6Resellers.Domain.Companies.ResellerCustomer", "ResellerCustomer")
                        .WithMany("ProductResellerCustomers")
                        .HasForeignKey("ResellerCustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Level6Resellers.Domain.Companies.ResellerCompany", "ResellerCompany")
                        .WithMany("ProductResellerCustomers")
                        .HasForeignKey("ResellerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Level6Resellers.Domain.Purchases.Purchase", b =>
                {
                    b.HasOne("Level6Resellers.Domain.Companies.CustomerCompany", "CustomerCompany")
                        .WithMany("Purchases")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Level6Resellers.Domain.Products.Product", "Product")
                        .WithMany("Purchases")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Level6Resellers.Domain.Products.ProductResellerCustomer", "ProductResellerCustomer")
                        .WithMany("Purchases")
                        .HasForeignKey("ProductResellerCustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Level6Resellers.Domain.Companies.ResellerCompany", "ResellerCompany")
                        .WithMany("Purchases")
                        .HasForeignKey("ResellerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Level6Resellers.Domain.Users.UserCustomer", "UserCustomer")
                        .WithMany("Purchases")
                        .HasForeignKey("UserCustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Level6Resellers.Domain.Users.UserCustomer", b =>
                {
                    b.HasOne("Level6Resellers.Domain.Companies.CustomerCompany", "CustomerCompany")
                        .WithMany("Users")
                        .HasForeignKey("CustomerCompanyId");
                });
#pragma warning restore 612, 618
        }
    }
}
