using AgroHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgroHub.Infrastructure.Data.Mapping
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("TB_Product");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                    .IsRequired(true)
                    .HasColumnName("id_product");

            builder.Property(p => p.Name)
                   .HasColumnName("name")
                   .HasColumnType("Varchar(100)")
                   .IsRequired(true)
                   .HasMaxLength(100);

            builder.Property(p => p.Description)
                   .HasColumnName("description")
                   .HasColumnType("Varchar(200)")
                   .IsRequired(true)
                   .HasMaxLength(200);

            builder.Property(p => p.CreateDate)
                   .HasColumnName("create_date");

            builder.Property(p => p.Image)
                   .HasColumnName("image")
                   .HasColumnType("Varchar(200)")
                   .HasMaxLength(200);

            builder.Property(p => p.Value)
                   .HasColumnName("value")
                   .IsRequired(true)
                   .HasColumnType("decimal(10,2)");

            builder.Property(p => p.Quantity)
                   .HasColumnName("quantity")
                   .IsRequired(true)
                   .HasColumnType("int");

            builder.Property(p => p.Unit)
                   .HasColumnName("unit")
                   .HasColumnType("Varchar(20)");
        }
    }
}
