using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vrata24.Core.Entities;

namespace Vrata24.Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.ProductName).IsRequired().HasMaxLength(120);
            builder.Property(p => p.ProductDescription).IsRequired().HasMaxLength(250);
            builder.Property(p => p.ProductPrice).HasColumnType("decimal(18,2)");
            builder.Property(p => p.PictureUrl).IsRequired();
            builder.HasOne(b => b.ProductBrand).WithMany()
            .HasForeignKey(p => p.ProductBrandId);
            builder.HasOne(t => t.ProductType).WithMany()
            .HasForeignKey(p => p.ProductTypeId);
        }
    }
}