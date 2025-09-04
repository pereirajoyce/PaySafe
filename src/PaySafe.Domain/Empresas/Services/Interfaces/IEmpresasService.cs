using PaySafe.Domain.Empresas.Commands;
using PaySafe.Domain.Empresas.Entities;

namespace PaySafe.Domain.Empresas.Services.Interfaces
{
    public interface IEmpresasService
    {
        Task<Empresa> EditarAsync(Guid guid, EmpresaEditarCommand command, CancellationToken cancellationToken);
        Task<Empresa> InserirAsync(EmpresaCommand command, CancellationToken cancellationToken);
        Task<Empresa> ValidarAsync(Guid guid, CancellationToken cancellationToken);
        Task<Empresa> RecuperarAsync(Guid guid, CancellationToken cancellationToken);
        Task ExcluirAsync(Guid guid, CancellationToken cancellationToken);
    }
}
