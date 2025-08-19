using PaySafe.Application.Planos.DataTransfer.Requests;
using PaySafe.Application.Planos.DataTransfer.Responses;

namespace PaySafe.Application.Planos.Services.Interfaces
{
    public interface IPlanosAppService
    {
        Task<PlanoResponse> EditarAsync(Guid guid, PlanoEditarRequest request, CancellationToken cancellationToken);
        Task<PlanoResponse> InserirAsync(PlanoInserirRequest request, CancellationToken cancellationToken);
        Task<PlanoResponse> RecuperarAsync(Guid guid, CancellationToken cancellationToken);
        Task ExcluirAsync(Guid guid, CancellationToken cancellationToken);
    }
}
