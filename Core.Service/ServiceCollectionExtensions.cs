using Core.Domain.Common;
using Core.Utility;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRuntimeConfig<T>(this IServiceCollection services, IConfiguration config) where T : CConfig
        {
            var obj = Activator.CreateInstance<T>();
            config.Bind(obj);
            RuntimeContext.Config = obj;
            return services;
        }
    }
}
