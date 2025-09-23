using PaySafe.Domain.Common;

namespace PaySafe.Application.Planos.DataTransfer.Requests
{
    public class TransacaoListarFiltroRequest : PaginacaoConsulta
    {
        public TransacaoListarFiltroRequest() : base(pg: 1, qtd: 10, ordenacaoPor: "Id", ordenacao: "Asc") { }
    }
}