using PaySafe.Application.Common.Consultas.DataTransfer.Responses;
using PaySafe.Application.Planos.DataTransfer.Requests;
using PaySafe.Application.Transacoes.DataTransfer.Requests;
using PaySafe.Application.Transacoes.DataTransfer.Responses;

namespace PaySafe.Application.Transacoes.Services.Interfaces
{
    public interface ITransacoesAppService
    {
        Task<TransacaoResponse> InserirAsync(TransacaoInserirRequest request, CancellationToken cancellationToken);
        Task<TransacaoResponse> EditarAsync(Guid guid, TransacaoEditarRequest request, CancellationToken cancellationToken);
        Task<TransacaoResponse> ValidarAsync(Guid guid, CancellationToken cancellationToken);
        Task ExcluirAsync(Guid guid, CancellationToken cancellationToken);
        Task<PaginacaoResponse<TransacaoResponse>> ListarComPaginacaoAsync(TransacaoListarFiltroRequest filtro, CancellationToken cancellationToken);
    }
}
