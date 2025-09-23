using PaySafe.Domain.Common;

namespace PaySafe.Application.Gateways.DataTransfer.Requests
{
    public class GatewayListarFiltro : PaginacaoConsulta
    {
        public GatewayListarFiltro() : base(pg: 1, qtd: 10, ordenacaoPor: "Id", ordenacao: "Asc") { }
    }
}
