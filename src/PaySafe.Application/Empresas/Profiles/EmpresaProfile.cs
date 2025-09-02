using Mapster;
using PaySafe.Application.Empresas.DataTransfer.Responses;
using PaySafe.Application.Planos.DataTransfer.Responses;
using PaySafe.Domain.Empresas.Entities;
using PaySafe.Domain.Planos.Entities;

namespace PaySafe.Application.Empresas.Profiles
{
    public class EmpresaProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Empresa, EmpresaResponse>()
                .Map(d => d.PlanoGuid, s => s.Plano.Guid);
        }
    }
}
