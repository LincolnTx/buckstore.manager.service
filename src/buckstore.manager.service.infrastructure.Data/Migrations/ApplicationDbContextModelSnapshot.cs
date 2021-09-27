﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using buckstore.manager.service.infrastructure.Data.Context;

namespace buckstore.manager.service.infrastructure.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("buckstore.manager.service.domain.Aggregates.ProductAggregate.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("character varying(300)")
                        .HasMaxLength(300);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnName("price")
                        .HasColumnType("numeric");

                    b.Property<int>("Stock")
                        .HasColumnName("stock_quantity")
                        .HasColumnType("integer");

                    b.Property<int>("_categoryId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("_categoryId");

                    b.ToTable("product");
                });

            modelBuilder.Entity("buckstore.manager.service.domain.Aggregates.ProductAggregate.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("description")
                        .HasColumnType("character varying(80)")
                        .HasMaxLength(80);

                    b.HasKey("Id");

                    b.ToTable("product_category");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Gamer"
                        },
                        new
                        {
                            Id = 2,
                            Name = "SmartPhones"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Computador"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Periféricos"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Hardware"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Office"
                        });
                });

            modelBuilder.Entity("buckstore.manager.service.domain.Aggregates.SalesAggregate.Sale", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("_code")
                        .IsRequired()
                        .HasColumnName("Code")
                        .HasColumnType("text");

                    b.Property<int>("_discountPercentage")
                        .HasColumnName("DiscountPercentage")
                        .HasColumnType("integer");

                    b.Property<DateTime>("_expirationDate")
                        .HasColumnName("ExpirationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal>("_minimumValue")
                        .HasColumnName("MinimumValue")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("sale");
                });

            modelBuilder.Entity("buckstore.manager.service.domain.Aggregates.ProductAggregate.Product", b =>
                {
                    b.HasOne("buckstore.manager.service.domain.Aggregates.ProductAggregate.ProductCategory", "Category")
                        .WithMany()
                        .HasForeignKey("_categoryId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.OwnsMany("buckstore.manager.service.domain.Aggregates.ProductAggregate.ProductsImage", "Images", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uuid");

                            b1.Property<string>("ContentType")
                                .HasColumnType("text");

                            b1.Property<byte[]>("Image")
                                .HasColumnType("bytea");

                            b1.Property<Guid>("product_id")
                                .HasColumnType("uuid");

                            b1.HasKey("Id");

                            b1.HasIndex("product_id");

                            b1.ToTable("ProductsImage");

                            b1.WithOwner()
                                .HasForeignKey("product_id");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
