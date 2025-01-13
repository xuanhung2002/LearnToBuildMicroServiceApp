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
            return services;
        }
    }
}
