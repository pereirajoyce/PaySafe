using Mapster;
using PaySafe.Application.Common.Consultas.DataTransfer.Responses;
using PaySafe.Application.Common.NHibernate;
using PaySafe.Application.Common.NHibernate.Interfaces;
using PaySafe.Application.Empresas.DataTransfer.Requests;
using PaySafe.Application.Empresas.DataTransfer.Responses;
using PaySafe.Application.Empresas.Services.Interfaces;
using PaySafe.Domain.Empresas.Commands;
using PaySafe.Domain.Empresas.Repositories;
using PaySafe.Domain.Empresas.Services.Interfaces;

namespace PaySafe.Application.Empresas.Services
{
    public class EmpresasAppService(IEmpresasService empresasService, IEmpresasRepository empresasRepository, IUnitOfWork unitOfWork) : IEmpresasAppService
    {
        public async Task<EmpresaResponse> RecuperarAsync(Guid guid, CancellationToken cancellationToken)
        {
            try
            {
                var response = await empresasService.RecuperarAsync(guid, cancellationToken);

                return response.Adapt<EmpresaResponse>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<EmpresaResponse> InserirAsync(EmpresaInserirRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var command = request.Adapt<EmpresaCommand>();

                unitOfWork.BeginTransaction();

                var response = await empresasService.InserirAsync(command, cancellationToken);

                await unitOfWork.CommitAsync(cancellationToken);

                return response.Adapt<EmpresaResponse>();

            }
            catch (Exception)
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task<EmpresaResponse> EditarAsync(Guid guid, EmpresaEditarRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var command = request.Adapt<EmpresaEditarCommand>();

                unitOfWork.BeginTransaction();

                var response = await empresasService.EditarAsync(guid, command, cancellationToken);

                await unitOfWork.CommitAsync(cancellationToken);

                return response.Adapt<EmpresaResponse>();
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

                await empresasService.ExcluirAsync(guid, cancellationToken);

                await unitOfWork.CommitAsync(cancellationToken);
            }
            catch (Exception)
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task<PaginacaoResponse<EmpresaResponse>> ListarComPaginacaoAsync(EmpresaListarFiltroRequest filtro, CancellationToken cancellationToken)
        {
            try
            {
                var (empresas, total) = await empresasRepository.ListarComPaginacaoAsync(
                    filtro,
                    filtro.Pg,
                    filtro.Qtd,
                    filtro.OrdenacaoPor ?? "Id",
                    filtro.Ordenacao,
                    cancellationToken);

                return new PaginacaoResponse<EmpresaResponse>
                {
                    Pg = filtro.Pg,
                    Qtd = filtro.Qtd,
                    Total = total,
                    Itens = empresas.Adapt<IEnumerable<EmpresaResponse>>()
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}