using PaySafe.CrossCutting.Enums;

namespace PaySafe.Domain.Transacoes.Commands
{
    public class TransacaoEditarCommand
    {
        public StatusEnum Status { get; set; }
    }
}
