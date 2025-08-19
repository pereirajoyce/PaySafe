namespace PaySafe.Domain.Planos.Commands
{
    public class PlanoCommand
    {
        public string Nome { get; protected set; }
        public double Mensalidade { get; protected set; }
        public int Volume { get; protected set; }
        public  double ValorExcedente { get; protected set; }
        public int MaximoUsuarios { get; protected set; } = 1;
        public int MaximoGrupos { get; protected set; } = 1;
    }
}
