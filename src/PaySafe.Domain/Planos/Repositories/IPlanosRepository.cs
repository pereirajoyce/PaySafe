using PaySafe.Domain.Common.Interfaces;
using PaySafe.Domain.Planos.Entities;

namespace PaySafe.Domain.Planos.Repositories
{
    public interface IPlanosRepository : INHibernateRepository<Plano>
    {
    }
}
