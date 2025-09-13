using PaySafe.Domain.Common;

namespace PaySafe.Application.Planos.DataTransfer.Requests
{
    public class PlanoListarFiltroRequest : PaginacaoConsulta
    {
        public PlanoListarFiltroRequest() : base(pg: 1, qtd: 10, ordenacaoPor: "Id", ordenacao: "Asc") { }
    }
}