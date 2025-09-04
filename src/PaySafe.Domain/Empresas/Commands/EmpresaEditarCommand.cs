using PaySafe.Domain.ValueObjects;

namespace PaySafe.Domain.Empresas.Commands
{
    public class EmpresaEditarCommand
    {
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public Cnpj Cnpj { get; set; }
        public Guid Plano { get; set; }
    }
}
