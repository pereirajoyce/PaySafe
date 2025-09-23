using System.ComponentModel;

namespace PaySafe.Domain.Gateways.Enums
{
    public enum ServicoEnum
    {
        [Description("Cielo")]
        Cielo = 0,

        [Description("GetNet")]
        Getnet = 1,

        [Description("PagBank")]
        PagBank = 2
    }
}
