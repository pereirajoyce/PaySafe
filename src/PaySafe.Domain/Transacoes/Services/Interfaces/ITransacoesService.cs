using PaySafe.Domain.Transacoes.Commands;
using PaySafe.Domain.Transacoes.Entities;

namespace PaySafe.Domain.Transacoes.Services.Interfaces
{
    public interface ITransacoesService
    {
        Task<Transacao> InserirAsync(TransacaoCommand command, CancellationToken cancellationToken);
        Task<Transacao> EditarAsync(Guid guid, TransacaoEditarCommand command, CancellationToken cancellationToken);
        Task ExcluirAsync(Guid guid, CancellationToken cancellationToken);
        Task<Transacao> RecuperarAsync(Guid guid, CancellationToken cancellationToken);
        Task<Transacao> ValidarAsync(Guid guid, CancellationToken cancellationToken);
    }
}
