using NHibernate;
using PaySafe.Domain.Planos.Entities;
using PaySafe.Domain.Planos.Repositories;
using PaySafe.Infrastructure.Common;

namespace PaySafe.Infrastructure.Planos.Repositories
{
    public class PlanosRepository(ISession session) : NHibernateRepository<Plano>(session), IPlanosRepository
    {

    }
}
