using System.Reflection;

namespace PaySafe.API.Extensions
{
    public static class HostExtensions
    {
        public static WebApplicationBuilder ConfigureHost(this WebApplicationBuilder builder)
        {
            var port = $"http://*:{builder.Configuration["Application:Port"]}";

            builder.Configuration
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                 .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
                 .AddEnvironmentVariables();

            builder.WebHost.UseUrls(port);

            return builder;
        }
    }
}
