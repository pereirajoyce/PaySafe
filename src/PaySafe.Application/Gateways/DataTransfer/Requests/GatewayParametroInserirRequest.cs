namespace PaySafe.Application.Gateways.DataTransfer.Requests
{
    public class GatewayParametroInserirRequest
    {
        public string Chave { get; set; }
        public string Valor { get; set; }
        public Guid GatewayGuid { get; set; }
    }
}
