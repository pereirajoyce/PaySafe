
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PaySafe.IoC.Configurations;

namespace PaySafe.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration, IHostEnvironment env)
        {
            services.AddNHibernate(configuration, env);
        }
    }
}

