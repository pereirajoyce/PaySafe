using PaySafe.Domain.ValueObjects;

namespace PaySafe.Application.Usuarios.DataTransfer.Responses
{
    public class UsuarioResponse
    {
        public Guid Guid { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public Cpf Cpf { get; set; }
        public Email Email { get; set; }
        public Guid Empresa { get; set; }
        public string Telefone { get; set; }
    }
}
