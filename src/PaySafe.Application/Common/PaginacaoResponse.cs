namespace PaySafe.Application.Common
{
    public class PaginacaoResponse<T>
    {
        public int Pg { get; set; }
        public int Qtd { get; set; }
        public int Total { get; set; }
        public IEnumerable<T> Itens { get; set; } = [];
    }
}