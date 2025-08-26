using PaySafe.Domain.Empresas.Entities;
using PaySafe.Domain.Usuarios.Commands;
using PaySafe.Domain.ValueObjects;

namespace PaySafe.Domain.Usuarios.Entities
{
    public class Usuario
    {
        public virtual int Id { get; protected set; } 
        public virtual Guid Guid { get; protected set; } = Guid.NewGuid();
        public virtual string Nome { get; protected set; }
        public virtual string Sobrenome { get; protected set; }
        public virtual Cpf Cpf { get; protected set; }
        public virtual Email Email { get; protected set; }
        public virtual Empresa Empresa { get; protected set; }
        public virtual string Telefone { get; protected set; }
        public virtual bool Excluido { get; protected set; } = false;

        protected Usuario() { }

        public Usuario(UsuarioCommand command)
        {
            SetNome(command.Nome);
            SetSobrenome(command.Sobrenome);
            SetCpf(command.Cpf);
            SetEmpresa(command.Empresa);
            SetTelefone(command.Telefone);
            SetEmail(command.Email);
        }

        public virtual void SetNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome não pode ser vazio ou nulo.", nameof(nome));

            Nome = nome;
        }

        public virtual void SetSobrenome(string sobrenome)
        {
            if (string.IsNullOrWhiteSpace(sobrenome))
                throw new ArgumentException("Sobrenome não pode ser vazio ou nulo.", nameof(sobrenome));

            Sobrenome = sobrenome;
        }

        public virtual void SetCpf(Cpf cpf)
        {
            Cpf = new Cpf(cpf.Numero);
        }

        public virtual void SetEmpresa(Empresa empresa)
        {
            Empresa = empresa;
        }

        public virtual void SetEmail(Email email)
        {
            Email = new Email(email.Endereco);
        }

        public virtual void SetTelefone(string telefone)
        {
            Telefone = telefone;
        }

        public virtual void SetExcluido()
        {
            Excluido = true;
        }
    }
}
