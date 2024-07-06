using AgroHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgroHub.Infrastructure.Data.Mapping
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("TB_Category");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .HasColumnName("id_category");

            builder.Property(c => c.Name)
                .HasColumnName("name")
                .HasColumnType("Varchar(100)")
                .IsRequired(true);

        }
    }
}
