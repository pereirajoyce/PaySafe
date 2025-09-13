using PaySafe.Domain.Common;

namespace PaySafe.Application.Empresas.DataTransfer.Requests
{
    public class EmpresaListarFiltroRequest : PaginacaoConsulta
    {
        public EmpresaListarFiltroRequest() : base(pg: 1, qtd: 10, ordenacaoPor: "Id", ordenacao: "Asc") { }
    }
}