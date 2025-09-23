using Microsoft.AspNetCore.Mvc;
using PaySafe.Application.Common.Consultas.DataTransfer.Responses;
using PaySafe.Application.Gateways.DataTransfer.Requests;
using PaySafe.Application.Gateways.DataTransfer.Responses;
using PaySafe.Application.Gateways.Services.Interfaces;

namespace PaySafe.API.Controllers.Gateways
{
    [Route("api/gateway-parametros")]
    [ApiController]
    public class GatewayParametrosController(IGatewayParametrosAppService gatewayParametrosAppService) : ControllerBase
    {
        /// <summary>
        /// Cria um novo gateway parametro.
        /// </summary>
        [HttpPost]
        [ProducesResponseType<GatewayParametroResponse>(StatusCodes.Status201Created)]
        public async Task<IActionResult> InserirAsync([FromBody] GatewayParametroInserirRequest request, CancellationToken cancellationToken)
        {
            var gateway = await gatewayParametrosAppService.InserirAsync(request, cancellationToken);
            return Ok(gateway);
        }

        /// <summary>
        /// Edita um gateway parametro existente.
        /// </summary>
        [HttpPut("{guid}")]
        [ProducesResponseType<GatewayParametroResponse>(StatusCodes.Status201Created)]
        public async Task<IActionResult> EditarAsync(Guid guid, [FromBody] GatewayParametroEditarRequest request, CancellationToken cancellationToken)
        {
            var gateway = await gatewayParametrosAppService.EditarAsync(guid, request, cancellationToken);
            return Ok(gateway);
        }

        /// <summary>
        /// Recupera um gateway parametro pelo GUID.
        /// </summary>
        [HttpGet("{guid}")]
        [ProducesResponseType<GatewayParametroResponse>(StatusCodes.Status201Created)]
        public async Task<IActionResult> RecuperarAsync(Guid guid, CancellationToken cancellationToken)
        {
            var gateway = await gatewayParametrosAppService.RecuperarAsync(guid, cancellationToken);
            return Ok(gateway);
        }

        /// <summary>
        /// Exclui um gateway parametro pelo GUID.
        /// </summary>
        [HttpDelete("{guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> ExcluirAsync(Guid guid, CancellationToken cancellationToken)
        {
            await gatewayParametrosAppService.ExcluirAsync(guid, cancellationToken);
            return NoContent();
        }

        /// <summary>
        /// Listagem de gateway parametros com paginação.
        /// </summary>
        [HttpGet()]
        [ProducesResponseType<PaginacaoResponse<GatewayParametroResponse>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> ListarComPaginacaoAsync([FromQuery] GatewayParametroListarFiltro filtro, CancellationToken cancellationToken)
        {
            var response = await gatewayParametrosAppService.ListarComPaginacaoAsync(filtro, cancellationToken);
            return Ok(response);
        }
    }
}
