using PaySafe.Application.Common.Consultas.DataTransfer.Responses;
using PaySafe.Application.Pagamentos.DataTramsfer.Requests;
using PaySafe.Application.Pagamentos.DataTramsfer.Responses;

namespace PaySafe.Application.Pagamentos.Services.Interfaces
{
    public interface IPagamentosAppService
    {
        Task<PagamentoResponse> InserirAsync(PagamentoRequest request, CancellationToken cancellationToken);
        Task<PagamentoResponse> EditarAsync(Guid guid, PagamentoEditarRequest request, CancellationToken cancellationToken);
        Task<PagamentoResponse> RecuperarAsync(Guid guid, CancellationToken cancellationToken);
        Task<PaginacaoResponse<PagamentoResponse>> ListarComPaginacaoAsync(PagamentoListarFiltroRequest filtro, CancellationToken cancellationToken);
        Task ExcluirAsync(Guid guid, CancellationToken cancellationToken);
    }
}
