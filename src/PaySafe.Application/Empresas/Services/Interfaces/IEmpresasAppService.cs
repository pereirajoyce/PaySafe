using PaySafe.Application.Empresas.DataTransfer.Requests;
using PaySafe.Application.Empresas.DataTransfer.Responses;

namespace PaySafe.Application.Empresas.Services.Interfaces
{
    public interface IEmpresasAppService
    {
        Task<EmpresaResponse> RecuperarAsync(Guid guid, CancellationToken cancellationToken);
        Task<EmpresaResponse> InserirAsync(EmpresaInserirRequest request, CancellationToken cancellationToken);
        Task<EmpresaResponse> EditarAsync(Guid guid, EmpresaEditarRequest request, CancellationToken cancellationToken);
        Task ExcluirAsync(Guid guid, CancellationToken cancellationToken);
    }
}
