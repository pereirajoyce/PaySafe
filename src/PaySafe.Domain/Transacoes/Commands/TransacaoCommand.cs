using PaySafe.CrossCutting.Enums;

namespace PaySafe.Domain.Transacoes.Commands
{
    public class TransacaoCommand
    {
        public int PrecoTotal { get; set; }
        public int Taxa { get; set; }
        public string Itens { get; set; }
        public StatusEnum Status { get; set; }
        public Guid EmpresaGuid { get; set; }
    }
}
