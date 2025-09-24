using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;

namespace PaySafe.IoC.Configurations.HttpClients
{
    public static class HttpClientsConfig
    {
        public static IServiceCollection AddHttpClients(this IServiceCollection services, IConfiguration configuration)
        {
            var cieloSection = configuration.GetSection("Brokers:Cielo");
            var baseUrl = cieloSection["BaseUrl"];
            var merchantId = cieloSection.GetSection("Credentials")["MerchantId"];
            var merchantKey = cieloSection.GetSection("Credentials")["MerchantKey"];

            services.AddHttpClient("Cielo.Api", client =>
            {
                client.BaseAddress = new Uri(baseUrl!);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Add("MerchantId", merchantId);
                client.DefaultRequestHeaders.Add("MerchantKey", merchantKey);
            });

            return services;
        }
    }
}
