
using Autofac.Extensions.DependencyInjection;
using Autofac;
using my_cs_project.IOC;
using my_cs_project.Configurations.Consul;
using my_cs_project.Entities.Context;
using my_cs_project.Entities.Seeds;

namespace my_cs_project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

            builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
            {
                // Register Autofac modules
                builder.RegisterModule(new AutofacModules());
            });

            //use swagger
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            app.UseCors("AllowAll");

            app.UseSwagger();
            app.UseSwaggerUI();

            app.MapControllers();

            app.UseConsulRegistry(app.Lifetime);


            app.MapControllers();

            app.UseRouting();

            app.MapGet("/api/health", () =>
            {
                return new { Message = "OK" };
            });

            using (var scope = app.Services.CreateScope())
            {
                var dbContext = app.Services.GetRequiredService<PortfolioDbContext>();

                // **delete database**
                dbContext.Database.EnsureDeleted();

                // **recreate database**
                dbContext.Database.EnsureCreated();
                // seed
                SeedData.Initialize(dbContext);
            }

            app.Run();
        }
    }
}
