using Mapster;
using PaySafe.Application.Provedores.DataTransfer;

namespace PaySafe.Application.Provedores.Profiles
{
    public class CieloProfiles : IRegister 
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<HttpResponseMessage, CieloBinResponse>();
        }
    }
}
