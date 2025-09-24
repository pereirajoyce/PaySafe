using Mapster;
using PaySafe.Application.Common.Consultas.DataTransfer.Responses;
using PaySafe.Application.Common.NHibernate.Interfaces;
using PaySafe.Application.Pagamentos.DataTramsfer.Requests;
using PaySafe.Application.Pagamentos.DataTramsfer.Responses;
using PaySafe.Application.Pagamentos.Services.Interfaces;
using PaySafe.Domain.Pagamentos.Commands;
using PaySafe.Domain.Pagamentos.Repositories;
using PaySafe.Domain.Pagamentos.Services.Interfaces;

namespace PaySafe.Application.Pagamentos.Services
{
    public class PagamentosAppService(IPagamentosService pagamentosService, IPagamentosRepository pagamentosRepository, IUnitOfWork unitOfWork) : IPagamentosAppService
    {
        public async Task<PagamentoResponse> InserirAsync(PagamentoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var command = request.Adapt<PagamentoCommand>();

                unitOfWork.BeginTransaction();

                var response = await pagamentosService.InserirAsync(command, request.TransacaoGuid, cancellationToken);

                await unitOfWork.CommitAsync(cancellationToken);

                return response.Adapt<PagamentoResponse>();
            }
            catch (Exception)
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task<PagamentoResponse> EditarAsync(Guid guid, PagamentoEditarRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var command = request.Adapt<PagamentoEditarCommand>();

                unitOfWork.BeginTransaction();

                var response = await pagamentosService.EditarAsync(guid, command, cancellationToken);

                await unitOfWork.CommitAsync(cancellationToken);

                return response.Adapt<PagamentoResponse>();
            }
            catch (Exception)
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task<PagamentoResponse> RecuperarAsync(Guid guid, CancellationToken cancellationToken)
        {

            try
            {
                var response = await pagamentosService.ValidarAsync(guid, cancellationToken);

                return response.Adapt<PagamentoResponse>();
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

                await pagamentosService.ExcluirAsync(guid, cancellationToken);

                await unitOfWork.CommitAsync(cancellationToken);
            }
            catch (Exception)
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task<PaginacaoResponse<PagamentoResponse>> ListarComPaginacaoAsync(PagamentoListarFiltroRequest filtro, CancellationToken cancellationToken)
        {
            try
            {
                var (pagamentos, total) = await pagamentosRepository.ListarComPaginacaoAsync(
                    filtro,
                    filtro.Pg,
                    filtro.Qtd,
                    filtro.OrdenacaoPor ?? "Id",
                    filtro.Ordenacao,
                    cancellationToken);

                return new PaginacaoResponse<PagamentoResponse>
                {
                    Pg = filtro.Pg,
                    Qtd = filtro.Qtd,
                    Total = total,
                    Itens = pagamentos.Adapt<IEnumerable<PagamentoResponse>>()
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
