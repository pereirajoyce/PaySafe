using PaySafe.Domain.ValueObjects;

namespace PaySafe.Application.Empresas.DataTransfer.Responses
{
    public class EmpresaResponse
    {
        public Guid Guid { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public Cnpj Cnpj { get; set; }
        public Guid Plano { get; set; }
    }
}
