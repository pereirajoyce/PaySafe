using PaySafe.Domain.Common.Interfaces;
using PaySafe.Domain.Gateways.Entities;

namespace PaySafe.Domain.Gateways.Repositories
{
    public interface IGatewaysRepository : INHibernateRepository<Gateway>
    {
    }
}
