using NHibernate;
using PaySafe.Domain.Empresas.Repositories;
using PaySafe.Domain.Planos.Entities;
using PaySafe.Infrastructure.Common;

namespace PaySafe.Infrastructure.Empresas.Repositories
{
    public class EmpresasRepository(ISession session) : NHibernateRepository<Plano>(session), IEmpresasRepository
    {
    }
}
