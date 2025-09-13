using Mapster;
using PaySafe.Application.Common;
using PaySafe.Application.Usuarios.DataTransfer.Requests;
using PaySafe.Application.Usuarios.DataTransfer.Responses;
using PaySafe.Application.Usuarios.Services.Interfaces;
using PaySafe.Domain.Common;
using PaySafe.Domain.Usuarios.Commands;
using PaySafe.Domain.Usuarios.Repositories;
using PaySafe.Domain.Usuarios.Services.Interfaces;

namespace PaySafe.Application.Usuarios.Services
{
    public class UsuarioAppService(IUsuariosService usuariosService, IUsuariosRepository usuariosRepository) : IUsuariosAppService
    {
        public async Task<UsuarioResponse> InserirAsync(UsuarioInserirRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var command = request.Adapt<UsuarioCommand>();

                var response = await usuariosService.InserirAsync(command, cancellationToken);

                return response.Adapt<UsuarioResponse>();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Um erro ocorreu ao tentar inserir o usuario.", ex);
            }
        }

        public async Task<UsuarioResponse> EditarAsync(Guid guid, UsuarioEditarRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var command = request.Adapt<UsuarioEditarCommand>();

                var response = await usuariosService.EditarAsync(guid, command, cancellationToken);

                return response.Adapt<UsuarioResponse>();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Um erro ocorreu ao tentar editar o usuario.", ex);
            }
        }

        public async Task<UsuarioResponse> RecuperarAsync(Guid guid, CancellationToken cancellationToken)
        {
            try
            {
                var response = await usuariosService.RecuperarAsync(guid, cancellationToken);

                return response.Adapt<UsuarioResponse>();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Um erro ocorreu ao tentar recuperar o usuario.", ex);
            }
        }

        public async Task ExcluirAsync(Guid guid, CancellationToken cancellationToken)
        {
            try
            {
                await usuariosService.ExcluirAsync(guid, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Um erro ocorreu ao tentar excluir o usuario.", ex);
            }
        }

        public async Task<PaginacaoResponse<UsuarioResponse>> ListarComPaginacaoAsync(UsuarioListarFiltro filtro, CancellationToken cancellationToken)
        {
            try
            {
                var (usuarios, total) = await usuariosRepository.ListarComPaginacaoAsync(
                    filtro,                   
                    filtro.Pg,
                    filtro.Qtd,
                    filtro.OrdenacaoPor ?? "ID",
                    filtro.Ordenacao,
                    cancellationToken);

                return new PaginacaoResponse<UsuarioResponse>
                {
                    Pg = filtro.Pg,
                    Qtd = filtro.Qtd,
                    Total = total,
                    Itens = usuarios.Adapt<IEnumerable<UsuarioResponse>>()
                };
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Um erro ocorreu ao tentar listar os usuários com paginação.", ex);
            }
        }
    }
}
