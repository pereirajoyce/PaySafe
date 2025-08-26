using Asp.Versioning;
using Microsoft.Extensions.DependencyInjection;

namespace PaySafe.IoC.Configurations.Versioning
{
    public static class VersioningConfig
    {
        public static IServiceCollection AddVersioning(this IServiceCollection services)
        {
            var builder = services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1.0);
                options.ReportApiVersions = true;
                options.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader());
            });

            builder.AddApiExplorer(conf =>
            {
                conf.GroupNameFormat = "'v'V";
                conf.SubstituteApiVersionInUrl = true;
            });

            return services;
        }
    }
}
