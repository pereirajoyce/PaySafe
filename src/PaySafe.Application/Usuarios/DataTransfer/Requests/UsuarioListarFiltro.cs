using PaySafe.Domain.Common;

namespace PaySafe.Application.Usuarios.DataTransfer.Requests
{
    public class UsuarioListarFiltro : PaginacaoConsulta
    {
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }

        public UsuarioListarFiltro() : base(pg: 1, qtd: 10, ordenacaoPor: "Id", ordenacao: "Asc") { }
    }
}
