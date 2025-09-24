using PaySafe.Domain.ValueObjects;

namespace PaySafe.Domain.Usuarios.Commands
{
    public class UsuarioEditarCommand
    {
        public virtual string Nome { get; protected set; }
        public virtual string Sobrenome { get; protected set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public virtual Cpf Cpf { get; protected set; }
        public virtual Email Email { get; protected set; }
        public virtual string Telefone { get; protected set; }
    }
}
