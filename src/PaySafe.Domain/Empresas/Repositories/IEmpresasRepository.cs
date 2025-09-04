using PaySafe.Domain.Common.Interfaces;
using PaySafe.Domain.Empresas.Commands;
using PaySafe.Domain.Empresas.Entities;

namespace PaySafe.Domain.Empresas.Repositories
{
    public interface IEmpresasRepository : INHibernateRepository<Empresa>
    {
    }
}
