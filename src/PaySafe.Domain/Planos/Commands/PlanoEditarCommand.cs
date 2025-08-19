namespace PaySafe.Domain.Planos.Commands
{
    public class PlanoEditarCommand
    {
        public string Nome { get; set; }
        public double Mensalidade { get; set; }
        public int Volume { get; set; }
        public double ValorExcedente { get; set; }
        public int MaximoUsuarios { get; set; }
        public int MaximoGrupos { get; set; }
    }
}
