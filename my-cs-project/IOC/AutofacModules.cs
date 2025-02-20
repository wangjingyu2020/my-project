using Autofac;
using Azure;
using Azure.AI.OpenAI;
using my_cs_project.Services;
using my_cs_project.Services.Impl;

namespace my_cs_project.IOC
{
    public class AutofacModules : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OpenAiService>().As<IOpenAiService>().InstancePerDependency();
            builder.Register(c =>
            {
                var configuration = c.Resolve<IConfiguration>();
                return new AzureOpenAIClient(
                    new Uri(configuration["OpenAi:endpoint"]),
                    new AzureKeyCredential(configuration["OpenAi:openAiKey"]));
            }).SingleInstance();
        }

    }
}
