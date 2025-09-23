namespace PaySafe.Application.Gateways.DataTransfer.Responses
{
    public class GatewayParametroResponse
    {
        public Guid Guid { get; set; }
        public string Chave { get; set; }
        public string Valor { get; set; }
        public Guid GatewayGuid {  get; set; }
    }
}
