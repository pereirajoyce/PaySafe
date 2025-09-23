using System.ComponentModel;

namespace PaySafe.CrossCutting.Enums
{
    public enum StatusEnum
    {
        [Description("Pendente")]
        Pendente = 0,

        [Description("Sucesso")]
        Sucesso = 1,

        [Description("Cancelado")]
        Cancelado = 2,

        [Description("Erro")]
        Erro = 3,

        [Description("Estornado")]
        Estornado = 4
    }
}
