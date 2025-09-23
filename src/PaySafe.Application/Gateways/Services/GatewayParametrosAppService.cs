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
    public class GatewayParametrosAppService(IGatewayParametrosService gatewayParametrosService, IGatewayParametrosRepository gatewayParametrosRepository, IUnitOfWork unitOfWork) : IGatewayParametrosAppService
    {
        public async Task<GatewayParametroResponse> InserirAsync(GatewayParametroInserirRequest request, CancellationToken cancellationToken)
        {
            try
            {
                unitOfWork.BeginTransaction();

                var gatewayParametro = await gatewayParametrosService.InserirAsync(request.Chave, request.Valor, request.GatewayGuid, cancellationToken);

                await unitOfWork.CommitAsync(cancellationToken);

                return gatewayParametro.Adapt<GatewayParametroResponse>();

            }
            catch (Exception)
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task<GatewayParametroResponse> EditarAsync(Guid guid, GatewayParametroEditarRequest request, CancellationToken cancellationToken)
        {
            try
            {
                unitOfWork.BeginTransaction();

                var gatewayParametro = await gatewayParametrosService.EditarAsync(guid, request.Chave, request.Valor, cancellationToken);

                await unitOfWork.CommitAsync(cancellationToken);

                return gatewayParametro.Adapt<GatewayParametroResponse>();

            }
            catch (Exception)
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task<GatewayParametroResponse> RecuperarAsync(Guid guid, CancellationToken cancellationToken)
        {
            try
            {

                var gatewayParametro = await gatewayParametrosService.RecuperarAsync(guid, cancellationToken);

                return gatewayParametro.Adapt<GatewayParametroResponse>();

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

                await gatewayParametrosService.ExcluirAsync(guid, cancellationToken);

                await unitOfWork.CommitAsync(cancellationToken);

            }
            catch (Exception)
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task<PaginacaoResponse<GatewayParametroResponse>> ListarComPaginacaoAsync(GatewayParametroListarFiltro filtro, CancellationToken cancellationToken)
        {
            try
            {
                var (planos, total) = await gatewayParametrosRepository.ListarComPaginacaoAsync(
                    filtro,
                    filtro.Pg,
                    filtro.Qtd,
                    filtro.OrdenacaoPor ?? "Id",
                    filtro.Ordenacao,
                    cancellationToken);

                return new PaginacaoResponse<GatewayParametroResponse>
                {
                    Pg = filtro.Pg,
                    Qtd = filtro.Qtd,
                    Total = total,
                    Itens = planos.Adapt<IEnumerable<GatewayParametroResponse>>()
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
