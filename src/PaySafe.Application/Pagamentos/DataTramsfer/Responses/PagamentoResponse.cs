using PaySafe.CrossCutting.Enums;
using PaySafe.Domain.Transacoes.Enums;

namespace PaySafe.Application.Pagamentos.DataTramsfer.Responses
{
    public class PagamentoResponse
    {
        public Guid Guid { get; set; }
        public MetodoPagamentoEnum Metodo { get; set; }
        public int Valor { get; set; }
        public StatusEnum Status { get; set; }
        public DateTime DataCriacao { get; set; } 
        public Guid TransacaoGuid { get; set; }
    }
}
