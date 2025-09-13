using Mapster;
using PaySafe.Application.Common.Consultas.DataTransfer.Responses;
using PaySafe.Application.Common.NHibernate.Interfaces;
using PaySafe.Application.Usuarios.DataTransfer.Requests;
using PaySafe.Application.Usuarios.DataTransfer.Responses;
using PaySafe.Application.Usuarios.Services.Interfaces;
using PaySafe.Domain.Usuarios.Commands;
using PaySafe.Domain.Usuarios.Repositories;
using PaySafe.Domain.Usuarios.Services.Interfaces;

namespace PaySafe.Application.Usuarios.Services
{
    public class UsuarioAppService(IUsuariosService usuariosService, IUsuariosRepository usuariosRepository, IUnitOfWork unitOfWork) : IUsuariosAppService
    {
        public async Task<UsuarioResponse> InserirAsync(UsuarioInserirRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var command = request.Adapt<UsuarioCommand>();

                unitOfWork.BeginTransaction();

                var response = await usuariosService.InserirAsync(command, cancellationToken);

                await unitOfWork.CommitAsync(cancellationToken);

                return response.Adapt<UsuarioResponse>();
            }
            catch (Exception)
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task<UsuarioResponse> EditarAsync(Guid guid, UsuarioEditarRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var command = request.Adapt<UsuarioEditarCommand>();

                unitOfWork.BeginTransaction();

                var response = await usuariosService.EditarAsync(guid, command, cancellationToken);

                await unitOfWork.CommitAsync(cancellationToken);

                return response.Adapt<UsuarioResponse>();
            }
            catch (Exception)
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task<UsuarioResponse> RecuperarAsync(Guid guid, CancellationToken cancellationToken)
        {
            try
            {
                var response = await usuariosService.RecuperarAsync(guid, cancellationToken);

                return response.Adapt<UsuarioResponse>();
            }
            catch (Exception)
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task ExcluirAsync(Guid guid, CancellationToken cancellationToken)
        {
            try
            {
                unitOfWork.BeginTransaction();

                await usuariosService.ExcluirAsync(guid, cancellationToken);

                await unitOfWork.CommitAsync(cancellationToken);
            }
            catch (Exception)
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task<PaginacaoResponse<UsuarioResponse>> ListarComPaginacaoAsync(UsuarioListarFiltroRequest filtro, CancellationToken cancellationToken)
        {
            try
            {
                var (usuarios, total) = await usuariosRepository.ListarComPaginacaoAsync(
                    filtro,                   
                    filtro.Pg,
                    filtro.Qtd,
                    filtro.OrdenacaoPor ?? "Id",
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
            catch (Exception)
            {
                throw;
            }
        }
    }
}
