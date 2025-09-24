using System.Text.Json.Serialization;

namespace PaySafe.Application.Provedores.DataTransfer
{
    /// <summary>
    /// Representa a resposta da API Cielo para consulta de BIN de cartão.
    /// </summary>
    public class CieloBinResponse
    {
        /// <summary>
        /// Status da requisição de análise de Bins:
        /// 00 – Análise autorizada
        /// 01 – Bandeira não suportada
        /// 02 – Cartão não suportado na consulta de bin
        /// 73 – Afiliação bloqueada
        /// </summary>
        [JsonPropertyName("Status")]
        public string Status { get; set; } = null!;

        /// <summary>
        /// Bandeira do cartão (ex.: Visa, Mastercard, Elo). Máx: 255 caracteres
        /// </summary>
        [JsonPropertyName("Provider")]
        public string Provider { get; set; } = null!;

        /// <summary>
        /// Tipo do cartão em uso: Crédito, Débito ou Múltiplo. Máx: 20 caracteres
        /// </summary>
        [JsonPropertyName("CardType")]
        public string CardType { get; set; } = null!;

        /// <summary>
        /// Indica se o cartão é emitido no exterior.
        /// </summary>
        [JsonPropertyName("ForeingCard")]
        public bool ForeingCard { get; set; }

        /// <summary>
        /// Indica se o cartão é corporativo.
        /// </summary>
        [JsonPropertyName("CorporateCard")]
        public bool CorporateCard { get; set; }

        /// <summary>
        /// Nome do emissor do cartão. Máx: 255 caracteres
        /// </summary>
        [JsonPropertyName("Issuer")]
        public string Issuer { get; set; } = null!;

        /// <summary>
        /// Código do emissor do cartão. Máx: 255 caracteres
        /// </summary>
        [JsonPropertyName("IssuerCode")]
        public string IssuerCode { get; set; } = null!;

        /// <summary>
        /// Indica se o cartão é do tipo pré-pago.
        /// </summary>
        [JsonPropertyName("Prepaid")]
        public bool Prepaid { get; set; }
    }
}
