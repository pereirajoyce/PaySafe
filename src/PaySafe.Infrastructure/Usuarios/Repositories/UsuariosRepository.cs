using NHibernate;
using PaySafe.Domain.Usuarios.Entities;
using PaySafe.Domain.Usuarios.Repositories;
using PaySafe.Infrastructure.Common;

namespace PaySafe.Infrastructure.Usuarios.Repositories
{
    public class UsuariosRepository(ISession session) : NHibernateRepository<Usuario>(session), IUsuariosRepository
    {
    }
}
