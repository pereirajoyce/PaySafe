using PaySafe.CrossCutting.Exceptions;
using PaySafe.Domain.Empresas.Entities;
using PaySafe.Domain.Gateways.Enums;

namespace PaySafe.Domain.Gateways.Entities
{
    public class Gateway
    {
        public virtual int Id { get; protected set; }
        public virtual Guid Guid { get; protected set; } = Guid.NewGuid();
        public virtual ServicoEnum Servico { get; protected set; }
        public virtual int Prioridade { get; protected set; }
        public virtual Empresa Empresa { get; protected set; }

        protected Gateway() { }

        public Gateway(ServicoEnum servico, int prioridade, Empresa empresa)
        {
            SetServico(servico);
            SetPrioridade(prioridade);
            SetEmpresa(empresa);
        }

        public virtual void SetServico(ServicoEnum servico)
        {
            Servico = servico;
        }

        public virtual void SetPrioridade(int prioridade)
        {
            if (prioridade < 0)
                throw new AtributoInvalidoException(nameof(prioridade));

            Prioridade = prioridade;
        }

        public virtual void SetEmpresa(Empresa empresa)
        {
            Empresa = empresa;
        }
    }
}
