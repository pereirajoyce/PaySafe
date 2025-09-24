using PaySafe.Domain.Pagamentos.Commands;
using PaySafe.Domain.Pagamentos.Entities;

namespace PaySafe.Domain.Pagamentos.Services.Interfaces
{
    public interface IPagamentosService
    {
        Task<Pagamento> InserirAsync(PagamentoCommand command, Guid transacaoGuid, CancellationToken cancellationToken);
        Task<Pagamento> EditarAsync(Guid guid, PagamentoEditarCommand command, CancellationToken cancellationToken);
        Task<Pagamento> RecuperarAsync(Guid guid, CancellationToken cancellationToken);
        Task<Pagamento> ValidarAsync(Guid guid, CancellationToken cancellationToken);
        Task ExcluirAsync(Guid guid, CancellationToken cancellationToken);
    }
}
