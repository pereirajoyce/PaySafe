using Mapster;
using PaySafe.Application.Common.Consultas.DataTransfer.Responses;
using PaySafe.Application.Common.NHibernate.Interfaces;
using PaySafe.Application.Gateways.DataTransfer.Requests;
using PaySafe.Application.Gateways.DataTransfer.Responses;
using PaySafe.Application.Gateways.Services.Interfaces;
using PaySafe.Domain.Gateways.Repositories;
using PaySafe.Domain.Gateways.Services.Interfaces;

namespace PaySafe.Application.Gateways.Services
{
    public class GatewaysAppService(IGatewaysService gatewaysService, IGatewaysRepository gatewaysRepository, IUnitOfWork unitOfWork) : IGatewaysAppService
    {
        public async Task<GatewayResponse> InserirAsync(GatewayInserirRequest request, CancellationToken cancellationToken)
        {
            try
            {
                unitOfWork.BeginTransaction();

                var gateway = await gatewaysService.InserirAsync(request.Servico, request.Prioridade, request.EmpresaGuid, cancellationToken);

                await unitOfWork.CommitAsync(cancellationToken);

                return gateway.Adapt<GatewayResponse>();
            }
            catch (Exception)
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task<GatewayResponse> EditarAsync(Guid guid, GatewayEditarRequest request, CancellationToken cancellationToken)
        {
            try
            {
                unitOfWork.BeginTransaction();

                var gateway = await gatewaysService.EditarAsync(guid, request.Servico, request.Prioridade, request.EmpresaGuid, cancellationToken);

                await unitOfWork.CommitAsync(cancellationToken);

                return gateway.Adapt<GatewayResponse>();
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

                await gatewaysService.ExcluirAsync(guid, cancellationToken);

                await unitOfWork.CommitAsync(cancellationToken);
            }
            catch (Exception)
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task<GatewayResponse> RecuperarAsync(Guid guid, CancellationToken cancellationToken)
        {
            try
            {
                var gateway = await gatewaysService.RecuperarAsync(guid, cancellationToken);

                return gateway.Adapt<GatewayResponse>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PaginacaoResponse<GatewayResponse>> ListarComPaginacaoAsync(GatewayListarFiltro filtro, CancellationToken cancellationToken)
        {
            try
            {
                var (planos, total) = await gatewaysRepository.ListarComPaginacaoAsync(
                    filtro,
                    filtro.Pg,
                    filtro.Qtd,
                    filtro.OrdenacaoPor ?? "Id",
                    filtro.Ordenacao,
                    cancellationToken);

                return new PaginacaoResponse<GatewayResponse>
                {
                    Pg = filtro.Pg,
                    Qtd = filtro.Qtd,
                    Total = total,
                    Itens = planos.Adapt<IEnumerable<GatewayResponse>>()
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
