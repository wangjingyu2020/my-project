using Autofac;
using Microsoft.EntityFrameworkCore;
using my_cs_project.Entities.Context;
using my_cs_project.Services;
using my_cs_project.Services.Impl;

namespace my_cs_project.IOC
{
    public class AutofacModules : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SkillService>().As<ISkillService>().InstancePerDependency();

            builder.RegisterType<ProjectService>().As<IProjectService>().InstancePerDependency();



            

            builder.RegisterType<PortfolioDbContext>()
            .AsSelf()
            .As<DbContext>()
            .InstancePerLifetimeScope();

        }

    }
}
