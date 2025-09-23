using PaySafe.Application.Common.Consultas.DataTransfer.Responses;
using PaySafe.Application.Gateways.DataTransfer.Requests;
using PaySafe.Application.Gateways.DataTransfer.Responses;

namespace PaySafe.Application.Gateways.Services.Interfaces
{
    public interface IGatewayParametrosAppService
    {
        Task<GatewayParametroResponse> InserirAsync(GatewayParametroInserirRequest request, CancellationToken cancellationToken);
        Task<GatewayParametroResponse> EditarAsync(Guid guid, GatewayParametroEditarRequest request, CancellationToken cancellationToken);
        Task<GatewayParametroResponse> RecuperarAsync(Guid guid, CancellationToken cancellationToken);
        Task<PaginacaoResponse<GatewayParametroResponse>> ListarComPaginacaoAsync(GatewayParametroListarFiltro filtro, CancellationToken cancellationToken);
        Task ExcluirAsync(Guid guid, CancellationToken cancellationToken);

    }
}
