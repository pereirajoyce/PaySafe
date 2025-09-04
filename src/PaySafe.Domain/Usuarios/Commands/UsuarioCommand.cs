using PaySafe.Domain.Empresas.Entities;
using PaySafe.Domain.ValueObjects;

namespace PaySafe.Domain.Usuarios.Commands
{
    public class UsuarioCommand
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public Cpf Cpf { get; set; }
        public Email Email { get; set; }
        public Guid Empresa { get; set; }
        public string Telefone { get; set; }
    }
}
