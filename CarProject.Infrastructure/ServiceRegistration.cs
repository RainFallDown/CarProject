using CarProject.Core.Abstract;
using CarProject.Core.Abstract.Service;
using CarProject.Core.Model;
using CarProject.Core.Repository;
using CarProject.Infrastructure.Service;
using EasyNetQ;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarProject.Infrastructure
{
    public static class ServiceRegistration
    {

        public static IConfiguration Configuration { get; set; }

        public static void AddConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
        }

        public static void AddInfrastructure(this IServiceCollection services)
        {
            AddConfiguration();
            services.AddSingleton<IAdvertRepository, AdvertRepository>();
            services.AddSingleton<IAdvertVisitRepository, AdvertVisitRepository>();
            services.AddTransient<IAdvertService, AdvertService>();
            services.AddTransient<IAdvertVisitService, AdvertVisitService>();
            services.Configure<AppSettings>(options => Configuration.GetSection("AppSettings").Bind(options));
            var busConfiguration = Configuration.GetSection("BusConfiguration").Get<BusConfiguration>();
            services.AddSingleton<IBus>(RabbitHutch
                .CreateBus($"host ={busConfiguration.RabbitMqUri}:{busConfiguration.RabbitMqPort};" +
                            $" virtualHost =/;" +
                            $" username ={busConfiguration.RabbitMqUserName};" +
                            $" password ={busConfiguration.RabbitMqPassword};" +
                            $" prefetchcount ={busConfiguration.PrefetchCount}"));

        }
    }
}
