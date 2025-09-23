using PaySafe.Application.Common.Consultas.DataTransfer.Responses;
using PaySafe.Application.Gateways.DataTransfer.Requests;
using PaySafe.Application.Gateways.DataTransfer.Responses;

namespace PaySafe.Application.Gateways.Services.Interfaces
{
    public interface IGatewaysAppService
    {
        Task<GatewayResponse> InserirAsync(GatewayInserirRequest request, CancellationToken cancellationToken);
        Task<GatewayResponse> EditarAsync(Guid guid, GatewayEditarRequest request, CancellationToken cancellationToken);
        Task<GatewayResponse> RecuperarAsync(Guid guid, CancellationToken cancellationToken);
        Task<PaginacaoResponse<GatewayResponse>> ListarComPaginacaoAsync(GatewayListarFiltro filtro, CancellationToken cancellationToken);
        Task ExcluirAsync(Guid guid, CancellationToken cancellationToken);
    }
}
