using System.ComponentModel;

namespace PaySafe.Domain.Transacoes.Enums
{
    public enum MetodoPagamentoEnum
    {
        [Description("Credito")]
        Credito = 0,

        [Description("Debito")]
        Debito = 1,

        [Description("Pix")]
        Pix = 2
    }
}
