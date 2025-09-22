using PaySafe.CrossCutting.Enums;

namespace PaySafe.Application.Transacoes.DataTransfer.Requests
{
    public class TransacaoInserirRequest
    {
        public int PrecoTotal { get; set; }
        public int Taxa { get; set; }
        public string Itens { get; set; }
        public StatusEnum Status { get; set; }
        public Guid EmpresaGuid { get; set; }
    }
}
