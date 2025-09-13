using PaySafe.Application.Common.Consultas.DataTransfer.Responses;
using PaySafe.Application.Usuarios.DataTransfer.Requests;
using PaySafe.Application.Usuarios.DataTransfer.Responses;

namespace PaySafe.Application.Usuarios.Services.Interfaces
{
    public interface IUsuariosAppService
    {
        Task<UsuarioResponse> InserirAsync(UsuarioInserirRequest request, CancellationToken cancellationToken);
        Task<UsuarioResponse> EditarAsync(Guid guid, UsuarioEditarRequest request, CancellationToken cancellationToken);
        Task<UsuarioResponse> RecuperarAsync(Guid guid, CancellationToken cancellationToken);
        Task<PaginacaoResponse<UsuarioResponse>> ListarComPaginacaoAsync(UsuarioListarFiltroRequest filtro, CancellationToken cancellationToken);
        Task ExcluirAsync(Guid guid, CancellationToken cancellationToken);
    }
}
