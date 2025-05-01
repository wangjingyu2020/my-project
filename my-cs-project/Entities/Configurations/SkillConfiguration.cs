using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using my_cs_project.Entities.Models;

namespace my_cs_project.Entities.Configurations
{
    public class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.ToTable("skills", schema: "portfolio");

            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();

            builder.Property(s => s.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            builder.Property(s => s.TechnologyId)
                .HasColumnName("technology_id")
                .IsRequired();

            builder.Property(s => s.Level)
                .HasColumnName("level")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(s => s.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

            builder.Property(s => s.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");

            builder.Property(s => s.IsDeleted)
                .HasColumnName("is_deleted")
                .HasDefaultValue(false);

            builder.HasOne(s => s.Technology)
                .WithMany()
                .HasForeignKey(s => s.TechnologyId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(s => s.UserId);

            builder.HasIndex(s => new { s.UserId, s.TechnologyId }).IsUnique();
        }
    }
}
