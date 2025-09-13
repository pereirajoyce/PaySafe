using Mapster;
using PaySafe.Application.Common.Consultas.DataTransfer.Responses;
using PaySafe.Application.Common.NHibernate.Interfaces;
using PaySafe.Application.Planos.DataTransfer.Requests;
using PaySafe.Application.Planos.DataTransfer.Responses;
using PaySafe.Application.Planos.Services.Interfaces;
using PaySafe.Domain.Planos.Commands;
using PaySafe.Domain.Planos.Repositories;
using PaySafe.Domain.Planos.Services.Interfaces;

namespace PaySafe.Application.Planos.Services
{
    public class PlanosAppService(IPlanosService planosService, IPlanosRepository planosRepository, IUnitOfWork unitOfWork) : IPlanosAppService
    {
        public async Task<PlanoResponse> EditarAsync(Guid guid, PlanoEditarRequest request, CancellationToken cancellationToken)
        {
            try
            {
                unitOfWork.BeginTransaction();

                var command = request.Adapt<PlanoEditarCommand>();

                var plano = await planosService.EditarAsync(guid, command, cancellationToken);

                await unitOfWork.CommitAsync(cancellationToken);

                return plano.Adapt<PlanoResponse>();
            }
            catch (Exception)
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task<PlanoResponse> InserirAsync(PlanoInserirRequest request, CancellationToken cancellationToken)
        {
            try
            {
                unitOfWork.BeginTransaction();

                var command = request.Adapt<PlanoCommand>();

                var plano = await planosService.InserirAsync(command, cancellationToken);

                await unitOfWork.CommitAsync(cancellationToken);

                return plano.Adapt<PlanoResponse>();
            }
            catch (Exception)
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task<PlanoResponse> RecuperarAsync(Guid guid, CancellationToken cancellationToken)
        {
            try
            {
                var plano = await planosService.RecuperarAsync(guid, cancellationToken);

                return plano.Adapt<PlanoResponse>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task ExcluirAsync(Guid guid, CancellationToken cancellationToken)
        {
            try
            {
                unitOfWork.BeginTransaction();

                await planosService.ExcluirAsync(guid, cancellationToken);

                await unitOfWork.CommitAsync(cancellationToken);
            }
            catch (Exception)
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task<PaginacaoResponse<PlanoResponse>> ListarComPaginacaoAsync(PlanoListarFiltroRequest filtro, CancellationToken cancellationToken)
        {
            try
            {
                var (planos, total) = await planosRepository.ListarComPaginacaoAsync(
                    filtro,
                    filtro.Pg,
                    filtro.Qtd,
                    filtro.OrdenacaoPor ?? "Id",
                    filtro.Ordenacao,
                    cancellationToken);

                return new PaginacaoResponse<PlanoResponse>
                {
                    Pg = filtro.Pg,
                    Qtd = filtro.Qtd,
                    Total = total,
                    Itens = planos.Adapt<IEnumerable<PlanoResponse>>()
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
