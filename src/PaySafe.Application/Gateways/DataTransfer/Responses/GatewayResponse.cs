using PaySafe.Domain.Gateways.Enums;

namespace PaySafe.Application.Gateways.DataTransfer.Responses
{
    public class GatewayResponse
    {
        public Guid Guid { get; set; }
        public ServicoEnum Servico { get; set; }
        public int Prioridade { get; set; }
        public Guid EmpresaGuid { get; set; }
    }
}
