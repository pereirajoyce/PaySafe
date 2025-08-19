using PaySafe.Domain.Planos.Entities;
using PaySafe.Domain.Planos.Repositories;
using PaySafe.Domain.Planos.Services.Interfaces;

namespace PaySafe.Domain.Planos.Services
{
    public class PlanosService(IPlanosRepository planosRepository) : IPlanosService
    {
        public async Task<Plano> RecuperarAsync(Guid guid, CancellationToken cancellationToken)
        {
            var plano = await planosRepository.RecuperarAsync(guid, cancellationToken);
            
            if (plano is null)
                throw new ArgumentNullException(nameof(plano));

            return plano;
        }
    }
}
