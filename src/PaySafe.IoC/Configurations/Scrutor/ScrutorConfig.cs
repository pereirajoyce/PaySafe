using Microsoft.Extensions.DependencyInjection;
using PaySafe.Application.Planos.Services.Interfaces;
using PaySafe.Domain.Planos.Services.Interfaces;
using PaySafe.Infrastructure.Planos.Repositories;
using Scrutor;
using System.Reflection;

namespace PaySafe.IoC.Configurations.Scrutor
{
    public static class ScrutorConfig
    {
        public static IServiceCollection InjetarDependenciasApplication(this IServiceCollection services)
        {
            services.ScanServices(typeof(IPlanosAppService).Assembly);
            return services;
        }

        public static IServiceCollection InjetarDependenciasDomain(this IServiceCollection services)
        {
            services.ScanServices(typeof(IPlanosService).Assembly);
            return services;
        }

        public static IServiceCollection InjetarDependenciasInfra(this IServiceCollection services)
        {
            services.ScanServices(typeof(PlanosRepository).Assembly);
            return services;
        }

        private static IServiceCollection ScanServices(this IServiceCollection services, Assembly assemby)
        {
            services.Scan(scan => scan
                .FromAssemblies(assemby)
                .AddClasses()
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsImplementedInterfaces(i => i.Namespace!.StartsWith("PaySafe"))
                .WithScopedLifetime());

            return services;
        }
    }
}
