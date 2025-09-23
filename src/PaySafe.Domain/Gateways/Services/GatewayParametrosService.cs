using PaySafe.CrossCutting.Exceptions;
using PaySafe.Domain.Gateways.Entities;
using PaySafe.Domain.Gateways.Repositories;
using PaySafe.Domain.Gateways.Services.Interfaces;

namespace PaySafe.Domain.Gateways.Services
{
    public class GatewayParametrosService(IGatewayParametrosRepository gatewayParametrosRepository, IGatewaysService gatewaysService) : IGatewayParametrosService
    {
        public async Task<GatewayParametro> InserirAsync(string chave, string valor, Guid gatewayGuid, CancellationToken cancellationToken)
        {
            var gateway = await gatewaysService.ValidarAsync(gatewayGuid, cancellationToken);

            var gatewayParametro = new GatewayParametro(chave, valor, gateway);

            await gatewayParametrosRepository.InserirAsync(gatewayParametro, cancellationToken);

            return gatewayParametro;
        }

        public async Task<GatewayParametro> EditarAsync(Guid gatewayParametroGuid, string chave, string valor, CancellationToken cancellationToken)
        {
            var gatewayParametro = await ValidarAsync(gatewayParametroGuid, cancellationToken);

            gatewayParametro.SetChave(chave ?? gatewayParametro.Chave);
            gatewayParametro.SetValor(valor ?? gatewayParametro.Valor);

            return gatewayParametro;
        }

        public async Task ExcluirAsync(Guid gatewayParametroGuid, CancellationToken cancellationToken)
        {
            var gatewayParametro = await ValidarAsync(gatewayParametroGuid, cancellationToken);

            await gatewayParametrosRepository.ExcluirAsync(gatewayParametro, cancellationToken);
        }

        public async Task<GatewayParametro> RecuperarAsync(Guid gatewayParametroGuid, CancellationToken cancellationToken)
        {
            var gatewayParametro = await gatewayParametrosRepository.RecuperarAsync(gatewayParametroGuid, cancellationToken);

            return gatewayParametro;
        }

        public async Task<GatewayParametro> ValidarAsync(Guid gatewayParametroGuid, CancellationToken cancellationToken)
        {
            var gatewayParametro = await gatewayParametrosRepository.RecuperarAsync(gatewayParametroGuid, cancellationToken);

            if (gatewayParametro == null)
                throw new RecursoNaoEncontradoException(nameof(gatewayParametro));

            return gatewayParametro;
        }
    }
}
