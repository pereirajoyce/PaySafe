using System.ComponentModel.DataAnnotations;

namespace PaySafe.Domain.Common
{
    public abstract class PaginacaoConsulta(int pg = 1, int qtd = 10, string? ordenacaoPor = null, string ordenacao = "ASC")
    {
        [Range(1, int.MaxValue, ErrorMessage = "Número da página deve ser maior que zero")]
        public int Pg { get; set; } = pg;

        [Range(1, 100, ErrorMessage = "Tamanho da página deve estar entre 1 e 100")]
        public int Qtd { get; set; } = qtd;

        /// <summary>
        /// Campo para ordenação (nome da propriedade)
        /// </summary>
        public string? OrdenacaoPor { get; set; } = ordenacaoPor;

        /// <summary>
        /// Direção da ordenação (asc ou desc)
        /// </summary>
        public string Ordenacao { get; set; } = ordenacao;
    }
}
