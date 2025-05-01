using Microsoft.EntityFrameworkCore;
using my_cs_project.Entities.Models;

namespace my_cs_project.Entities.Context
{
    public class PortfolioDbContext : DbContext
    {

        public DbSet<TechCategory> TechCategories { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SkillHistory> SkillHistories { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTechnology> ProjectsTechnologies { get; set; }
        public DbSet<UserProject> UsersProjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                string host = Environment.GetEnvironmentVariable("DB_HOST") ?? "localhost";
                string port = Environment.GetEnvironmentVariable("DB_PORT") ?? "3306";
                string database = Environment.GetEnvironmentVariable("DB_DATABASE") ?? "portfolio";
                string username = Environment.GetEnvironmentVariable("DB_USERNAME") ?? "root";
                string password = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "123456";

                string connStr = $"Server={host};Port={port};Database={database};User={username};Password={password}"; 
                optionsBuilder.UseMySQL(connStr);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
