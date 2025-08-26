using PaySafe.Domain.Planos.Entities;
using PaySafe.Domain.ValueObjects;

namespace PaySafe.Domain.Empresas.Commands
{
    public class EmpresaCommand
    {
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public Cnpj Cnpj { get; set; }
        public Plano Plano { get; set; }
    }
}
