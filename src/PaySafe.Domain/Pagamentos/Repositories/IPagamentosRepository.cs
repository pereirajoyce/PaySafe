using PaySafe.Domain.Common.Interfaces;
using PaySafe.Domain.Pagamentos.Entities;

namespace PaySafe.Domain.Pagamentos.Repositories
{
    public interface IPagamentosRepository : INHibernateRepository<Pagamento>
    {
    }
}
