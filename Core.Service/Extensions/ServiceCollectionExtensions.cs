using Core.Domain;
using Core.Service.MQ;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace Core.Service.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMQ(this IServiceCollection services)
        {
            services.AddSingleton(new ConnectionFactory()
            {
                HostName = "localhost",               
            });

            services.AddScoped<IMQClient, MQClient>();
            services.AddScoped<IMQCommand, MQCommand>();
            return services;
        }
    }
}
