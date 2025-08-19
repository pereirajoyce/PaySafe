using Mapster;
using PaySafe.Application.Empresas.DataTransfer.Requests;
using PaySafe.Application.Empresas.DataTransfer.Responses;
using PaySafe.Domain.Empresas.Commands;
using PaySafe.Domain.Empresas.Entities;

namespace PaySafe.Application.Empresas.Profiles
{
    public class EmpresaProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Empresa, EmpresaResponse>();
            config.NewConfig<EmpresaInserirRequest, EmpresaCommand>();
            config.NewConfig<EmpresaEditarRequest, EmpresaCommand>();
        }
    }
}
