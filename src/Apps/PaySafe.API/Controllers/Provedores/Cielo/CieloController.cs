using Microsoft.AspNetCore.Mvc;
using PaySafe.Application.Provedores.DataTransfer;
using PaySafe.Application.Provedores.Services.Interfaces;

namespace PaySafe.API.Controllers.Provedores.Cielo
{
    [Route("api/pagamento/cielo")]
    [ApiController]
    public class CieloController(ICieloAppService cieloAppService) : ControllerBase
    {
        /// <summary>
        /// Valida BIN do Cartao de Credito
        /// </summary>
        [HttpGet("{bin}")]
        [ProducesResponseType<CieloBinResponse>(StatusCodes.Status200OK)]
        public async Task<IActionResult> ConsultarBinDoCartaoAsync(string bin, CancellationToken cancellationToken)
        {
            var response = await cieloAppService.ConsultarBinDoCartaoAsync(bin, cancellationToken);
            return Ok(response);
        }
    }
}
