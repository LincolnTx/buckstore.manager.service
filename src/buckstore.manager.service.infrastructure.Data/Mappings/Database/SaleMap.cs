using System;
using buckstore.manager.service.domain.Aggregates.SalesAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace buckstore.manager.service.infrastructure.Data.Mappings.Database
{
    public class SaleMap : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("sale");

            builder.HasKey(sale => sale.Id);

            builder.Property<int>("_discountPercentage")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("DiscountPercentage")
                .IsRequired();

            builder.Property<DateTime>("_expirationDate")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("ExpirationDate")
                .IsRequired();

            builder.Property<string>("_code")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Code")
                .IsRequired();

            builder.Property<decimal>("_minimumValue")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("MinimumValue")
                .IsRequired();

            builder.HasIndex(sale => sale.Id)
                .IsUnique();
        }
    }
}
