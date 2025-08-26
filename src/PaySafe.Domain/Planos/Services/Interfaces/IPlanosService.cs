using PaySafe.Domain.Planos.Commands;
using PaySafe.Domain.Planos.Entities;

namespace PaySafe.Domain.Planos.Services.Interfaces
{
    public interface IPlanosService
    {
        Task<Plano> InserirAsync(PlanoCommand command, CancellationToken cancellationToken);
        Task<Plano> EditarAsync(Guid guid, PlanoEditarCommand command, CancellationToken cancellationToken);
        Task<Plano> RecuperarAsync(Guid guid, CancellationToken cancellationToken);
        Task ExcluirAsync(Guid guid, CancellationToken cancellationToken);
    }
}