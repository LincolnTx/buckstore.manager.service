using buckstore.manager.service.domain.Aggregates.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace buckstore.manager.service.infrastructure.Data.Mappings.Database
{
    public class ProductCategoryMap : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("product_category");

            builder.HasKey(category => category.Id);

            builder.Property(category => category.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(category => category.Name)
                .HasMaxLength(80)
                .HasColumnName("description")
                .IsRequired();

            builder.HasData(ProductCategory.Gamer, ProductCategory.SmartPhones, ProductCategory.Pc,
                ProductCategory.Gadgets, ProductCategory.Hardware, ProductCategory.Office);
        }
    }
}