using PaySafe.Domain.Gateways.Entities;
using PaySafe.Domain.Gateways.Enums;

namespace PaySafe.Domain.Gateways.Services.Interfaces
{
    public interface IGatewaysService
    {
        Task<Gateway> InserirAsync(ServicoEnum servico, int prioridade, Guid empresaGuid, CancellationToken cancellationToken);
        Task<Gateway> EditarAsync(Guid gatewayGuid, ServicoEnum servico, int prioridade, Guid empresaGuid, CancellationToken cancellationToken);
        Task<Gateway> RecuperarAsync(Guid gatewayGuid, CancellationToken cancellationToken);
        Task<Gateway> ValidarAsync(Guid gatewayGuid, CancellationToken cancellationToken);
        Task ExcluirAsync(Guid gatewayGuid, CancellationToken cancellationToken);
    }
}
