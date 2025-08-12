using Mapster;
using PaySafe.Application.Usuarios.DataTransfer.Requests;
using PaySafe.Application.Usuarios.DataTransfer.Responses;
using PaySafe.Domain.Usuarios.Commands;
using PaySafe.Domain.Usuarios.Entities;

namespace PaySafe.Application.Usuarios.Profiles
{
    public class UsuarioProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Usuario, UsuarioResponse>();
            config.NewConfig<UsuarioEditarRequest, UsuarioEditarCommand>();
            config.NewConfig<UsuarioInserirRequest, UsuarioInserirCommand>();
        }
    }
}
