using PaySafe.CrossCutting.Exceptions;
using PaySafe.Domain.Pagamentos.Commands;
using PaySafe.Domain.Pagamentos.Entities;
using PaySafe.Domain.Pagamentos.Repositories;
using PaySafe.Domain.Pagamentos.Services.Interfaces;
using PaySafe.Domain.Transacoes.Services.Interfaces;

namespace PaySafe.Domain.Pagamentos.Services
{
    public class PagamentosService(IPagamentosRepository pagamentosRepository, ITransacoesService transacoesService) : IPagamentosService
    {
        public async Task<Pagamento> InserirAsync(PagamentoCommand command, Guid transacaoGuid, CancellationToken cancellationToken)
        {
            var transacao = await transacoesService.ValidarAsync(transacaoGuid, cancellationToken);

            var pagamento = new Pagamento(command, transacao);

            await pagamentosRepository.InserirAsync(pagamento, cancellationToken);

            return pagamento;
        }

        public async Task<Pagamento> EditarAsync(Guid guid, PagamentoEditarCommand command, CancellationToken cancellationToken)
        {
            var pagamento = await ValidarAsync(guid, cancellationToken);

            if (command.Status != pagamento.Status)
                pagamento.SetStatus(command.Status);

            return pagamento;
        }

        public async Task ExcluirAsync(Guid guid, CancellationToken cancellationToken)
        {
            var pagamento = await ValidarAsync(guid, cancellationToken);

            await pagamentosRepository.ExcluirAsync(pagamento, cancellationToken);;
        }

        public async Task<Pagamento> RecuperarAsync(Guid guid, CancellationToken cancellationToken)
        {
            var pagamento = await  pagamentosRepository.RecuperarAsync(guid, cancellationToken);

            return pagamento;
        }

        public async Task<Pagamento> ValidarAsync(Guid guid, CancellationToken cancellationToken)
        {
            var pagamento = await pagamentosRepository.RecuperarAsync(guid, cancellationToken);

            if (pagamento == null)
                throw new RecursoNaoEncontradoException(nameof(pagamento));

            return pagamento;
        }
    }
}
