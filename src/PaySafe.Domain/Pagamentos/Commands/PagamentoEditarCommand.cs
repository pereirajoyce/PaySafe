using PaySafe.CrossCutting.Enums;

namespace PaySafe.Domain.Pagamentos.Commands
{
    public class PagamentoEditarCommand
    {
        public StatusEnum Status { get; set; }
    }
}
