using PaySafe.CrossCutting.Exceptions;
using PaySafe.Domain.Empresas.Commands;
using PaySafe.Domain.Planos.Entities;
using PaySafe.Domain.ValueObjects;

namespace PaySafe.Domain.Empresas.Entities
{
    public class Empresa
    {
        public virtual int Id { get; protected set; }
        public virtual Guid Guid { get; protected set; } = Guid.NewGuid();
        public virtual string RazaoSocial { get; protected set; }
        public virtual string NomeFantasia { get; protected set; }
        public virtual Cnpj Cnpj { get; protected set; }
        public virtual DateTime DataCriacao { get; protected set; } = DateTime.UtcNow;
        public virtual Plano Plano { get; protected set; }

        protected Empresa() { }

        public Empresa(EmpresaCommand command, Plano plano)
        {
            SetRazaoSocial(command.RazaoSocial);
            SetNomeFantasia(command.NomeFantasia);
            SetCnpj(command.Cnpj);
            SetPlano(plano);
        }

        public virtual void SetRazaoSocial(string razaoSocial)
        {
            if (string.IsNullOrWhiteSpace(razaoSocial))
                throw new AtributoObrigatorioException(nameof(razaoSocial));

            RazaoSocial = razaoSocial;
        }

        public virtual void SetNomeFantasia(string nomeFantasia)
        {
            if (string.IsNullOrWhiteSpace(nomeFantasia))
                throw new AtributoObrigatorioException(nameof(nomeFantasia));

            NomeFantasia = nomeFantasia;
        }

        public virtual void SetCnpj(Cnpj cnpj)
        {
            Cnpj = new Cnpj(cnpj.Numero);
        }

        public virtual void SetPlano(Plano plano)
        {
            Plano = plano;
        }
    }
}
