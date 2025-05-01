using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using my_cs_project.Entities.Models;

namespace my_cs_project.Entities.Configurations
{
    public class SkillHistoryConfiguration : IEntityTypeConfiguration<SkillHistory>
    {
        public void Configure(EntityTypeBuilder<SkillHistory> builder)
        {
            builder.ToTable("skill_histories", schema: "portfolio");

            builder.HasKey(sh => sh.Id);
            builder.Property(sh => sh.Id).ValueGeneratedOnAdd();

            builder.Property(sh => sh.SkillId)
                .HasColumnName("skill_id")
                .IsRequired();

            builder.Property(sh => sh.Year)
                .HasColumnName("year")
                .IsRequired();

            builder.Property(sh => sh.Popularity)
                .HasColumnName("popularity")
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(sh => sh.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

            builder.Property(sh => sh.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");

            builder.Property(sh => sh.IsDeleted)
                .HasColumnName("is_deleted")
                .HasDefaultValue(false);

            builder.HasOne(sh => sh.Skill)
                .WithMany()
                .HasForeignKey(sh => sh.SkillId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
