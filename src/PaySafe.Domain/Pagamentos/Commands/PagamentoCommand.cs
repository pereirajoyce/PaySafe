using PaySafe.CrossCutting.Enums;
using PaySafe.Domain.Transacoes.Enums;

namespace PaySafe.Domain.Pagamentos.Commands
{
    public class PagamentoCommand
    {
        public MetodoPagamentoEnum Metodo { get; set; }
        public int Valor { get; set; }
        public StatusEnum Status { get; set; }
    }
}
