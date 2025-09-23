using PaySafe.CrossCutting.Exceptions;
using PaySafe.Domain.Empresas.Services.Interfaces;
using PaySafe.Domain.Gateways.Entities;
using PaySafe.Domain.Gateways.Enums;
using PaySafe.Domain.Gateways.Repositories;
using PaySafe.Domain.Gateways.Services.Interfaces;

namespace PaySafe.Domain.Gateways.Services
{
    public class GatewaysService(IGatewaysRepository gatewaysRepository, IEmpresasService empresasService) : IGatewaysService
    {
        public async Task<Gateway> InserirAsync(ServicoEnum servico, int prioridade, Guid empresaGuid, CancellationToken cancellationToken)
        {
            var empresa = await empresasService.ValidarAsync(empresaGuid, cancellationToken);
            var gateway = new Gateway(servico, prioridade, empresa);

            await gatewaysRepository.InserirAsync(gateway, cancellationToken);
           
            return gateway;
        }

        public async Task<Gateway> EditarAsync(Guid gatewayGuid, ServicoEnum servico, int prioridade, Guid empresaGuid, CancellationToken cancellationToken)
        {
            var gateway = await ValidarAsync(gatewayGuid, cancellationToken);
            var empresa = await empresasService.ValidarAsync(empresaGuid, cancellationToken);

            gateway.SetServico(servico);
            gateway.SetEmpresa(empresa);
            gateway.SetPrioridade(prioridade);

            return gateway;
        }

        public async Task ExcluirAsync(Guid gatewayGuid, CancellationToken cancellationToken)
        {
            var gateway = await ValidarAsync(gatewayGuid, cancellationToken);

            await gatewaysRepository.ExcluirAsync(gateway, cancellationToken);
        }

        public async Task<Gateway> RecuperarAsync(Guid gatewayGuid, CancellationToken cancellationToken)
        {
            var gateway = await gatewaysRepository.RecuperarAsync(gatewayGuid, cancellationToken);

            return gateway;
        }

        public async Task<Gateway> ValidarAsync(Guid gatewayGuid, CancellationToken cancellationToken)
        {
            var gateway = await gatewaysRepository.RecuperarAsync(gatewayGuid, cancellationToken);

            if (gateway == null)
                throw new RecursoNaoEncontradoException(nameof(gateway));

            return gateway;
        }
    }
}
