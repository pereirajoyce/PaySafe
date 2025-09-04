using PaySafe.Application.Usuarios.DataTransfer.Requests;
using PaySafe.Application.Usuarios.DataTransfer.Responses;

namespace PaySafe.Application.Usuarios.Services.Interfaces
{
    public interface IUsuariosAppService
    {
        Task<UsuarioResponse> InserirAsync(UsuarioInserirRequest request, CancellationToken cancellationToken);
        Task<UsuarioResponse> EditarAsync(Guid guid, UsuarioEditarRequest request, CancellationToken cancellationToken);
        Task<UsuarioResponse> RecuperarAsync(Guid guid, CancellationToken cancellationToken);
        Task ExcluirAsync(Guid guid, CancellationToken cancellationToken);
    }
}
