using Mapster;
using Microsoft.Extensions.DependencyInjection;
using PaySafe.Application.Empresas.Services.Interfaces;
using PaySafe.Application.Planos.Services;
using PaySafe.Application.Planos.Services.Interfaces;

namespace PaySafe.IoC.Configurations.Mapster
{
    public static class MapsterConfig
    {
        public static IServiceCollection AddMapsterConfig(this IServiceCollection services)
        {
            var config = TypeAdapterConfig.GlobalSettings;

            config.Scan(typeof(IPlanosAppService).Assembly);
            config.Compile();

            return services;
        }
    }
}
