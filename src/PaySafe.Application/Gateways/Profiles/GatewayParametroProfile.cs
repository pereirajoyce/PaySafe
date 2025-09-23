using Mapster;
using PaySafe.Application.Gateways.DataTransfer.Responses;
using PaySafe.Domain.Gateways.Entities;

namespace PaySafe.Application.Gateways.Profiles
{
    public class GatewayParametroProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<GatewayParametro, GatewayParametroResponse>();
        }
    }
}
