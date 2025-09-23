using PaySafe.CrossCutting.Enums;
using PaySafe.CrossCutting.Exceptions;
using PaySafe.Domain.Empresas.Entities;
using PaySafe.Domain.Transacoes.Commands;

namespace PaySafe.Domain.Transacoes.Entities
{
    public class Transacao
    {
        public virtual int Id { get; protected set; }
        public virtual Guid Guid { get; protected set; } = Guid.NewGuid();
        public virtual int PrecoTotal { get; protected set; }
        public virtual int Taxa {  get; protected set; }
        public virtual int Frete { get; protected set; }
        public virtual string Itens { get; protected set; }
        public virtual StatusEnum Status { get; protected set; }
        public virtual Empresa Empresa { get; protected set; }

        protected Transacao() { }

        public Transacao(TransacaoCommand command, Empresa empresa)
        {
            SetPrecoTotal(command.PrecoTotal);
            SetTaxa(command.Taxa);
            SetFrete(command.Frete);
            SetItens(command.Itens);
            SetStatus(command.Status);
            SetEmpresa(empresa);
        }

        private void SetPrecoTotal(int precoTotal)
        {
            if (precoTotal <= 0)
                throw new AtributoInvalidoException(nameof(PrecoTotal));

            PrecoTotal = precoTotal;
        }

        private void SetTaxa(int taxa)
        {
            if (taxa <= 0)
                throw new AtributoInvalidoException(nameof(taxa));

            Taxa = taxa;
        }
        private void SetFrete(int frete)
        {
            if (frete < 0)
                throw new AtributoInvalidoException(nameof(frete));

            Frete = frete;
        }

        public virtual void SetItens(string itens)
        {
            if (string.IsNullOrWhiteSpace(itens))
                throw new AtributoObrigatorioException(nameof(itens));

            Itens = itens;
        }

        public virtual void SetStatus(StatusEnum status)
        {
            Status = status;
        }

        public virtual void SetEmpresa(Empresa empresa)
        {
            Empresa = empresa;
        }
    }
}
