using PaySafe.Domain.Common;

namespace PaySafe.Application.Pagamentos.DataTramsfer.Requests
{
    public class PagamentoListarFiltroRequest : PaginacaoConsulta
    {
        public PagamentoListarFiltroRequest() : base(pg: 1, qtd: 10, ordenacaoPor: "Id", ordenacao: "Asc") { }
    }
}
