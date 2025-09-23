using NHibernate;
using PaySafe.Domain.Pagamentos.Entities;
using PaySafe.Domain.Pagamentos.Repositories;
using PaySafe.Infrastructure.Common;

namespace PaySafe.Infrastructure.Pagamentos.Repositories
{
    public class PagamentosRepository(ISession session) : NHibernateRepository<Pagamento>(session), IPagamentosRepository
    {
    }
}
