using Mapster;
using PaySafe.Application.Common.Consultas.DataTransfer.Responses;
using PaySafe.Application.Common.NHibernate.Interfaces;
using PaySafe.Application.Planos.DataTransfer.Requests;
using PaySafe.Application.Transacoes.DataTransfer.Requests;
using PaySafe.Application.Transacoes.DataTransfer.Responses;
using PaySafe.Application.Transacoes.Services.Interfaces;
using PaySafe.Domain.Transacoes.Commands;
using PaySafe.Domain.Transacoes.Repositories;
using PaySafe.Domain.Transacoes.Services.Interfaces;

namespace PaySafe.Application.Transacoes.Services
{
    public class TransacoesAppService(ITransacoesService transacoesService, ITransacoesRepository transacoesRepository, IUnitOfWork unitOfWork) : ITransacoesAppService
    {
        public async Task<TransacaoResponse> InserirAsync(TransacaoInserirRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var command = request.Adapt<TransacaoCommand>();

                unitOfWork.BeginTransaction();

                var response = await transacoesService.InserirAsync(command, cancellationToken);

                await unitOfWork.CommitAsync(cancellationToken);

                return response.Adapt<TransacaoResponse>();
            }
            catch (Exception)
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task<TransacaoResponse> EditarAsync(Guid guid, TransacaoEditarRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var command = request.Adapt<TransacaoEditarCommand>();

                unitOfWork.BeginTransaction();

                var response = await transacoesService.EditarAsync(guid, command, cancellationToken);

                await unitOfWork.CommitAsync(cancellationToken);

                return response.Adapt<TransacaoResponse>();
            }
            catch (Exception)
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task<TransacaoResponse> ValidarAsync(Guid guid, CancellationToken cancellationToken)
        {
            try
            {
                var response = await transacoesService.ValidarAsync(guid, cancellationToken);

                return response.Adapt<TransacaoResponse>();
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

                await transacoesService.ExcluirAsync(guid, cancellationToken);

                await unitOfWork.CommitAsync(cancellationToken);
            }
            catch (Exception)
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task<PaginacaoResponse<TransacaoResponse>> ListarComPaginacaoAsync(TransacaoListarFiltroRequest filtro, CancellationToken cancellationToken)
        {
            try
            {
                var (transacoes, total) = await transacoesRepository.ListarComPaginacaoAsync(
                    filtro,
                    filtro.Pg,
                    filtro.Qtd,
                    filtro.OrdenacaoPor ?? "Id",
                    filtro.Ordenacao,
                    cancellationToken);

                return new PaginacaoResponse<TransacaoResponse>
                {
                    Pg = filtro.Pg,
                    Qtd = filtro.Qtd,
                    Total = total,
                    Itens = transacoes.Adapt<IEnumerable<TransacaoResponse>>()
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
