using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using my_cs_project.Entities.Models;

namespace my_cs_project.Entities.Configurations
{
    public class TechCategoryConfiguration : IEntityTypeConfiguration<TechCategory>
    {
        public void Configure(EntityTypeBuilder<TechCategory> builder)
        {
            builder.ToTable("tech_categories", schema: "portfolio");

            builder.HasKey(tc => tc.Id);
            builder.Property(tc => tc.Id).ValueGeneratedOnAdd();

            builder.Property(tc => tc.Name)
                .HasColumnName("name")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(tc => tc.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

            builder.Property(tc => tc.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");

            builder.Property(tc => tc.IsDeleted)
                .HasColumnName("is_deleted")
                .HasDefaultValue(false);
        }
    }
}
