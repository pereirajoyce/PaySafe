using PaySafe.Domain.Common.Interfaces;
using PaySafe.Domain.Usuarios.Entities;

namespace PaySafe.Domain.Usuarios.Repositories
{
    public interface IUsuariosRepository : INHibernateRepository<Usuario>
    {
    }
}
