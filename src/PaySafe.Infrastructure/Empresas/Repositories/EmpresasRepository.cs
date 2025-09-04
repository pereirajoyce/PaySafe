using NHibernate;
using PaySafe.Domain.Empresas.Entities;
using PaySafe.Domain.Empresas.Repositories;
using PaySafe.Infrastructure.Common;

namespace PaySafe.Infrastructure.Empresas.Repositories
{
    public class EmpresasRepository(ISession session) : NHibernateRepository<Empresa>(session), IEmpresasRepository
    {
    }
}
