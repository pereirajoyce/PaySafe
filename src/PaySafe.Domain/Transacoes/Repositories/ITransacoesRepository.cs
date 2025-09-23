using PaySafe.Domain.Common.Interfaces;
using PaySafe.Domain.Transacoes.Entities;

namespace PaySafe.Domain.Transacoes.Repositories
{
    public interface ITransacoesRepository : INHibernateRepository<Transacao>
    {
    }
}
