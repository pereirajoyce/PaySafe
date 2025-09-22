using PaySafe.CrossCutting.Exceptions;
using PaySafe.Domain.Empresas.Services.Interfaces;
using PaySafe.Domain.Transacoes.Commands;
using PaySafe.Domain.Transacoes.Entities;
using PaySafe.Domain.Transacoes.Repositories;
using PaySafe.Domain.Transacoes.Services.Interfaces;

namespace PaySafe.Domain.Transacoes.Services
{
    public class TransacoesService(ITransacoesRepository transacoesRepository, IEmpresasService empresasService) : ITransacoesService
    {
        public async Task<Transacao> InserirAsync(TransacaoCommand command, CancellationToken cancellationToken)
        {
            var empresa = await empresasService.ValidarAsync(command.EmpresaGuid, cancellationToken);

            var transacao = new Transacao(command, empresa);

            await transacoesRepository.InserirAsync(transacao, cancellationToken);

            return transacao;
        }

        public async Task<Transacao> EditarAsync(Guid guid, TransacaoEditarCommand command, CancellationToken cancellationToken)
        {
            var transacao = await transacoesRepository.RecuperarAsync(guid, cancellationToken);

            if (command.Status != transacao.Status)
            {
                transacao.SetStatus(command.Status);
                await transacoesRepository.EditarAsync(transacao, cancellationToken);
            }

            return transacao;
        }

        public async Task ExcluirAsync(Guid guid, CancellationToken cancellationToken)
        {
            var transacao = await ValidarAsync(guid, cancellationToken);

            await transacoesRepository.ExcluirAsync(transacao, cancellationToken);
        }

        public async Task<Transacao> RecuperarAsync(Guid guid,  CancellationToken cancellationToken)
        {
            var transacao = await transacoesRepository.RecuperarAsync(guid, cancellationToken);

            return transacao;
        }

        public async Task<Transacao> ValidarAsync(Guid guid, CancellationToken cancellationToken)
        {
            var transacao = await transacoesRepository.RecuperarAsync(guid, cancellationToken);

            if (transacao == null)
                throw new RecursoNaoEncontradoException(nameof(transacao));

            return transacao;
        }
    }
}
