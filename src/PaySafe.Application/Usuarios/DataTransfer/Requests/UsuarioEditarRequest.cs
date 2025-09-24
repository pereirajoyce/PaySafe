using PaySafe.Domain.ValueObjects;

namespace PaySafe.Application.Usuarios.DataTransfer.Requests
{
    public class UsuarioEditarRequest
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public Cpf Cpf { get; set; }
        public Email Email { get; set; }
        public string Telefone { get; set; }
    }
}
