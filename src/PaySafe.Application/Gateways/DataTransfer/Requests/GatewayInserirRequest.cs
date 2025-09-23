using PaySafe.Domain.Gateways.Enums;

namespace PaySafe.Application.Gateways.DataTransfer.Requests
{
    public class GatewayInserirRequest
    {
        public ServicoEnum Servico { get; set; }
        public int Prioridade { get; set; }
        public Guid EmpresaGuid { get; set; }
    }
}
