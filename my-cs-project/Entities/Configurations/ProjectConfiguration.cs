using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using my_cs_project.Entities.Models;

namespace my_cs_project.Entities.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("projects", schema: "portfolio");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                .HasColumnName("name")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.GithubUrl)
                .HasColumnName("github_url")
                .HasMaxLength(500);

            builder.Property(p => p.StartDate)
                .HasColumnName("start_date")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(p => p.EndDate)
                .HasColumnName("end_date")
                .HasColumnType("datetime");

            builder.Property(p => p.Description)
                .HasColumnName("description")
                .HasMaxLength(1000);

            builder.Property(p => p.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

            builder.Property(p => p.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");

            builder.Property(p => p.IsDeleted)
                .HasColumnName("is_deleted")
                .HasDefaultValue(false);
        }
    }
}
