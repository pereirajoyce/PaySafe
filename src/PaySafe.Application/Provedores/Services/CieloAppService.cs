using Mapster;
using PaySafe.Application.Provedores.DataTransfer;
using PaySafe.Application.Provedores.Services.Interfaces;
using PaySafe.Domain.Provedores.Repository;

namespace PaySafe.Application.Provedores.Services
{
    public class CieloAppService(ICieloRepository cieloRepository) : ICieloAppService
    {
        public async Task<CieloBinResponse> ConsultarBinDoCartaoAsync(string bin, CancellationToken cancellationToken)
        {
            try
            {
                var response = await cieloRepository.ConsultarBinDoCartaoAsync(bin, cancellationToken);

                return response.Adapt<CieloBinResponse>();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}