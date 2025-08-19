using PaySafe.Domain.Planos.Entities;

namespace PaySafe.Domain.Planos.Services.Interfaces
{
    public interface IPlanosService
    {
        Task<Plano> RecuperarAsync(Guid guid, CancellationToken cancellationToken);
    }
}
