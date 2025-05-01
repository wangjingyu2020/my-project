using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using my_cs_project.Entities.Models;

namespace my_cs_project.Entities.Configurations
{
    public class ProjectTechnologyConfiguration : IEntityTypeConfiguration<ProjectTechnology>
    {
        public void Configure(EntityTypeBuilder<ProjectTechnology> builder)
        {
            builder.ToTable("projects_technologies", schema: "portfolio"); // 复数形式

            builder.HasKey(pt => pt.Id);
            builder.Property(pt => pt.Id).ValueGeneratedOnAdd();

            builder.Property(pt => pt.ProjectId)
                .HasColumnName("project_id")
                .IsRequired();

            builder.Property(pt => pt.TechnologyId)
                .HasColumnName("technology_id")
                .IsRequired();

            builder.Property(pt => pt.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

            builder.Property(pt => pt.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");

            builder.HasOne(pt => pt.Project)
                .WithMany()
                .HasForeignKey(pt => pt.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pt => pt.Technology)
                .WithMany()
                .HasForeignKey(pt => pt.TechnologyId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(pt => new { pt.ProjectId, pt.TechnologyId }).IsUnique();
        }
    }
}
