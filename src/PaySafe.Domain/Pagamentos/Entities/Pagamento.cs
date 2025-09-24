using PaySafe.CrossCutting.Enums;
using PaySafe.CrossCutting.Exceptions;
using PaySafe.Domain.Pagamentos.Commands;
using PaySafe.Domain.Transacoes.Entities;
using PaySafe.Domain.Transacoes.Enums;

namespace PaySafe.Domain.Pagamentos.Entities
{
    public class Pagamento
    {
        public virtual int Id { get; protected set; }
        public virtual Guid Guid { get; protected set; } = Guid.NewGuid();
        public virtual MetodoPagamentoEnum Metodo { get; protected set; }
        public virtual int Valor { get; protected set; }
        public virtual StatusEnum Status { get; protected set; }
        public virtual DateTime DataCriacao { get; protected set; } = DateTime.Now;
        public virtual Transacao Transacao { get; protected set; }

        protected Pagamento() { }

        public Pagamento(PagamentoCommand command, Transacao transacao)
        {
            SetMetodo(command.Metodo);
            SetValor(command.Valor);
            SetStatus(command.Status);
            SetTransacao(transacao);
        }

        public virtual void SetMetodo(MetodoPagamentoEnum metodo)
        {
            Metodo = metodo;
        }

        public virtual void SetValor(int valor)
        {
            if (valor <= 0)
                throw new AtributoInvalidoException(nameof(valor));

            Valor = valor;
        }

        public virtual void SetStatus(StatusEnum status)
        {
            Status = status;
        }

        public virtual void SetTransacao(Transacao transacao)
        {
            Transacao = transacao;
        }
    }
}
