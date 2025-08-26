using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using PaySafe.IoC.Configurations.HttpClients;
using PaySafe.IoC.Configurations.Mapster;
using PaySafe.IoC.Configurations.NHibernate;
using PaySafe.IoC.Configurations.Scrutor;
using PaySafe.IoC.Configurations.Swagger;
using PaySafe.IoC.Configurations.Versioning;
using PaySafe.IoC.Settings;

namespace PaySafe.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void AddCommonServices(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {
            var builder = services.AddHealthChecks();
            services.AddCommonServices(configuration, environment, builder);
        }

        public static void AddCommonServices(this IServiceCollection services,
                                              IConfiguration configuration,
                                              IHostEnvironment environment,
                                              IHealthChecksBuilder hcBuilder)
        {
            services.Configure<ApplicationSettings>(configuration.GetSection("Application"));
           
            services.AddNHibernate(configuration, environment);
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddVersioning();
            services.AddSwagger();
            services.AddMapsterConfig();
            services.AddHttpContextAccessor();

            services.InjetarDependenciasApplication();
            services.InjetarDependenciasDomain();
            services.InjetarDependenciasInfra();

            services.AddHttpClients(configuration);
        }

        public static WebApplication UseCommonAppConfiguration(this WebApplication app)
        {
            var applicationSettings = app.Services.GetRequiredService<IOptions<ApplicationSettings>>().Value;

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });

            if (app.Environment.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UsePathBase(applicationSettings.PathBase);
            app.ConfigureSwagger(applicationSettings);
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            return app;
        }
    }
}