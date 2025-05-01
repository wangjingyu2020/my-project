using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using my_cs_project.Entities.Models;

namespace my_cs_project.Entities.Configurations
{
    public class UserProjectConfiguration : IEntityTypeConfiguration<UserProject>
    {
        public void Configure(EntityTypeBuilder<UserProject> builder)
        {
            builder.ToTable("users_projects", schema: "portfolio");

            builder.HasKey(up => up.Id);
            builder.Property(up => up.Id).ValueGeneratedOnAdd();

            builder.Property(up => up.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            builder.Property(up => up.ProjectId)
                .HasColumnName("project_id")
                .IsRequired();

            builder.Property(up => up.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime");

            builder.Property(up => up.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("datetime");

            builder.HasOne(up => up.Project)
                .WithMany()
                .HasForeignKey(up => up.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(up => up.UserId);

            builder.HasIndex(up => new { up.UserId, up.ProjectId }).IsUnique();
        }
    }
}
