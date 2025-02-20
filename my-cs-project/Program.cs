
using Autofac.Extensions.DependencyInjection;
using Autofac;
using my_cs_project.IOC;
using datacom_ai_test.Consul;

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

            app.Run();
        }
    }
}
