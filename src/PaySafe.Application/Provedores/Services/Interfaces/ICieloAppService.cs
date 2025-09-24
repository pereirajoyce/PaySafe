using PaySafe.Application.Provedores.DataTransfer;

namespace PaySafe.Application.Provedores.Services.Interfaces
{
    public interface ICieloAppService
    {
        Task<CieloBinResponse> ConsultarBinDoCartaoAsync(string bin, CancellationToken cancellationToken);
    }
}
