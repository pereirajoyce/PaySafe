using PaySafe.Application.Provedores.DataTransfer;
using PaySafe.Domain.Provedores.Repository;
using System.Net.Http.Json;

namespace PaySafe.Infrastructure.Provedores.Cielo
{
    public class CieloRepository(IHttpClientFactory httpClientFactory) : ICieloRepository
    {
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient("Cielo.Api");

        public async Task<HttpResponseMessage> ConsultarBinDoCartaoAsync(string bin, CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetAsync($"/1/cardBin/{bin}", cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                throw new Exception($"Erro na consulta Cielo: {response.StatusCode}, {content}");
            }

            return response;

        }
    }
}
