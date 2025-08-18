using PaySafe.Domain.ValueObjects;

namespace PaySafe.Domain.Usuarios.Commands
{
    public class UsuarioCommand
    {
        public string Nome { get; protected set; }
        public string Sobrenome { get; protected set; }
        public Cpf Cpf { get; protected set; }
        public Email Email { get; protected set; }
        public string Empresa { get; protected set; }
        public string Telefone { get; protected set; }
    }
}
