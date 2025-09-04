using PaySafe.Domain.Usuarios.Commands;
using PaySafe.Domain.Usuarios.Entities;

namespace PaySafe.Domain.Usuarios.Services.Interfaces
{
    public interface IUsuariosService
    {
        Task<Usuario> ValidarAsync(Guid guid, CancellationToken cancellationToken);
        Task<Usuario> RecuperarAsync(Guid guid, CancellationToken cancellationToken);
        Task<Usuario> InserirAsync(UsuarioCommand command, CancellationToken cancellationToken);
        Task<Usuario> EditarAsync(Guid guid, UsuarioEditarCommand command, CancellationToken cancellationToken);
        Task ExcluirAsync(Guid guid, CancellationToken cancellationToken);
    }
}
