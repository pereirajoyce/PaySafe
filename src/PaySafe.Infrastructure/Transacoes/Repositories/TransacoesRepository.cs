using NHibernate;
using PaySafe.Domain.Transacoes.Entities;
using PaySafe.Domain.Transacoes.Repositories;
using PaySafe.Infrastructure.Common;

namespace PaySafe.Infrastructure.Transacoes.Repositories
{
    public class TransacoesRepository(ISession session) : NHibernateRepository<Transacao>(session), ITransacoesRepository
    {
    }
}
