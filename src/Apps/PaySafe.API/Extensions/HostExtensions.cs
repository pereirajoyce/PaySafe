using Microsoft.AspNetCore.HttpOverrides;

namespace PaySafe.API.Extensions
{
    public static class HostExtensions
    {
        public static WebApplicationBuilder ConfigureHost(this WebApplicationBuilder builder)
        {
            builder.Configuration
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                 .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
                 .AddEnvironmentVariables();

            builder.WebHost.UseUrls(builder.Configuration.GetSection("Application:Port").Value);

            return builder;
        }

        public static WebApplication ConfigureBasePath(this WebApplication app)
        {
            string basePath = app.Configuration.GetSection("Application:Path").Value;

            if (!string.IsNullOrEmpty(basePath))
            {
                if (!basePath.StartsWith('/'))
                    basePath = "/" + basePath;

                app.UsePathBase(basePath);

                app.Use(async (context, next) =>
                {
                    context.Request.PathBase = basePath;
                    await next.Invoke();
                });
            }

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });

            return app;
        }
    }
}
