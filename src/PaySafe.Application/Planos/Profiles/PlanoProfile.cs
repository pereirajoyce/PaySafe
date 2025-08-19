using Mapster;
using PaySafe.Application.Planos.DataTransfer.Requests;
using PaySafe.Application.Planos.DataTransfer.Responses;
using PaySafe.Domain.Planos.Commands;
using PaySafe.Domain.Planos.Entities;

namespace PaySafe.Application.Planos.Profiles
{
    public class PlanoProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Plano, PlanoResponse>();
            config.NewConfig<PlanoInserirRequest, PlanoCommand>();
            config.NewConfig<PlanoEditarRequest, PlanoEditarCommand>();
        }
    }
}
