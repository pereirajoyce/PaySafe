using PaySafe.Domain.ValueObjects;

namespace PaySafe.Application.Empresas.DataTransfer.Requests
{
    public class EmpresaInserirRequest
    {
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public Cnpj Cnpj { get; set; }
        public Guid Plano { get; set; }
    }
}
