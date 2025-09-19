using PaySafe.CrossCutting.Exceptions;

namespace PaySafe.Domain.Gateways.Entities
{
    public class GatewayParametro
    {
        public virtual int Id { get; protected set; }
        public virtual Guid Guid { get; protected set; } = Guid.NewGuid();
        public virtual string Chave { get; protected set; }
        public virtual string Valor { get; protected set; }
        public virtual Gateway Gateway { get; protected set; }

        protected GatewayParametro() { }

        public GatewayParametro(string chave, string valor, Gateway gateway)
        {
            SetChave(chave);
            SetValor(valor);
            SetGateway(gateway);
        }

        public virtual void SetChave(string chave)
        {
            if (string.IsNullOrWhiteSpace(chave))
                throw new AtributoObrigatorioException(nameof(chave));
        }

        public virtual void SetValor(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new AtributoObrigatorioException(nameof(valor));

            Valor = valor;
        }

        public virtual void SetGateway(Gateway gateway)
        {
            Gateway = gateway;
        }
    }
}
