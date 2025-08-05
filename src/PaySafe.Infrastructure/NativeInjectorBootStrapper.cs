
using Microsoft.Extensions.DependencyInjection;

namespace PaySafe.Infrastructure
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Here you can register your services for Dependency Injection
            // Example:
            // services.AddScoped<IYourService, YourService>();
        }
    }
}

