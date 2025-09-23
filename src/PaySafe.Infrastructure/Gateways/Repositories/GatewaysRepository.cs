using NHibernate;
using PaySafe.Domain.Gateways.Entities;
using PaySafe.Domain.Gateways.Repositories;
using PaySafe.Infrastructure.Common;

namespace PaySafe.Infrastructure.Gateways.Repositories
{
    public class GatewaysRepository(ISession session) : NHibernateRepository<Gateway>(session), IGatewaysRepository
    {
    }
}
