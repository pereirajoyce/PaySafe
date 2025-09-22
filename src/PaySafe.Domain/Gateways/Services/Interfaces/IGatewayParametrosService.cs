using PaySafe.Domain.Gateways.Entities;

namespace PaySafe.Domain.Gateways.Services.Interfaces
{
    public interface IGatewayParametrosService
    {
        Task<GatewayParametro> InserirAsync(string chave, string valor, Guid gatewayGuid, CancellationToken cancellationToken);
        Task<GatewayParametro> EditarAsync(Guid gatewayParametroGuid, string chave, string valor, CancellationToken cancellationToken);
        Task<GatewayParametro> RecuperarAsync(Guid gatewayParametroGuid, CancellationToken cancellationToken);
        Task<GatewayParametro> ValidarAsync(Guid gatewayParametroGuid, CancellationToken cancellationToken);
        Task ExcluirAsync(Guid gatewayParametroGuid, CancellationToken cancellationToken);
    }
}
