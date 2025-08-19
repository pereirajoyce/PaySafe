using PaySafe.Domain.Planos.Commands;

namespace PaySafe.Domain.Planos.Entities
{
    public class Plano
    {
        public virtual int Id { get; protected set; }
        public virtual Guid Guid { get; protected set; } = Guid.NewGuid();
        public virtual string Nome { get; protected set; }
        public virtual double Mensalidade { get; protected set; }
        public virtual int Volume { get; protected set; }
        public virtual double ValorExcedente { get; protected set; }
        public virtual int MaximoUsuarios { get; protected set; } = 1;
        public virtual int MaximoGrupos { get; protected set; } = 1;

        protected Plano() { }

        public Plano(PlanoCommand command)
        {
            SetNome(command.Nome);
            SetMensalidade(command.Mensalidade);
            SetVolume(command.Volume);
            SetValorExcedente(command.ValorExcedente);
            SetMaximoUsuarios(command.MaximoUsuarios);
            SetMaximoGrupos(command.MaximoGrupos);
        }

        public virtual void SetNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentNullException(nameof(nome));

            Nome = nome;
        }

        public virtual void SetMensalidade(double mensalidade)
        {
            if (mensalidade < 0)
                throw new ArgumentNullException(nameof(mensalidade));

            Mensalidade = mensalidade;
        }

        public virtual void SetVolume(int volume)
        {
            if (volume < 0)
                throw new ArgumentNullException(nameof(volume));

            Volume = volume;
        }

        public virtual void SetValorExcedente(double valorExcedente)
        {
            if (valorExcedente  < 0)
                throw new ArgumentNullException(nameof(valorExcedente));

            ValorExcedente = valorExcedente;
        }

        public virtual void SetMaximoUsuarios(int maximoUsuarios)
        {
            if (maximoUsuarios < 0)
                throw new InvalidDataException(nameof(maximoUsuarios));

            MaximoUsuarios = maximoUsuarios;
        }

        public virtual void SetMaximoGrupos(int maximoGrupos)
        {
            if (maximoGrupos < 0)
                throw new InvalidDataException(nameof(maximoGrupos));

            MaximoGrupos = maximoGrupos;
        }
    }
}
