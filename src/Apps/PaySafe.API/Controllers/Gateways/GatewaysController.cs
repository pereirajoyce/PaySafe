using Microsoft.AspNetCore.Mvc;
using PaySafe.Application.Common.Consultas.DataTransfer.Responses;
using PaySafe.Application.Gateways.DataTransfer.Requests;
using PaySafe.Application.Gateways.DataTransfer.Responses;
using PaySafe.Application.Gateways.Services.Interfaces;

namespace PaySafe.API.Controllers.Gateways
{
    [Route("api/gateways")]
    [ApiController]
    public class GatewaysController(IGatewaysAppService gatewaysAppService) : ControllerBase
    {
        /// <summary>
        /// Cria um novo gateway.
        /// </summary>
        [HttpPost]
        [ProducesResponseType<GatewayResponse>(StatusCodes.Status201Created)]
        public async Task<IActionResult> InserirAsync([FromBody] GatewayInserirRequest request, CancellationToken cancellationToken)
        {
            var gateway = await gatewaysAppService.InserirAsync(request, cancellationToken);
            return Ok(gateway);
        }

        /// <summary>
        /// Edita um gateway existente.
        /// </summary>
        [HttpPut("{guid}")]
        [ProducesResponseType<GatewayResponse>(StatusCodes.Status201Created)]
        public async Task<IActionResult> EditarAsync(Guid guid, [FromBody] GatewayEditarRequest request, CancellationToken cancellationToken)
        {
            var gateway = await gatewaysAppService.EditarAsync(guid, request, cancellationToken);
            return Ok(gateway);
        }

        /// <summary>
        /// Recupera um gateway pelo GUID.
        /// </summary>
        [HttpGet("{guid}")]
        [ProducesResponseType<GatewayResponse>(StatusCodes.Status201Created)]
        public async Task<IActionResult> RecuperarAsync(Guid guid, CancellationToken cancellationToken)
        {
            var gateway = await gatewaysAppService.RecuperarAsync(guid, cancellationToken);
            return Ok(gateway);
        }

        /// <summary>
        /// Exclui um gateway pelo GUID.
        /// </summary>
        [HttpDelete("{guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> ExcluirAsync(Guid guid, CancellationToken cancellationToken)
        {
            await gatewaysAppService.ExcluirAsync(guid, cancellationToken);
            return NoContent();
        }

        /// <summary>
        /// Listagem de gateways com paginação.
        /// </summary>
        [HttpGet()]
        [ProducesResponseType<PaginacaoResponse<GatewayResponse>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> ListarComPaginacaoAsync([FromQuery] GatewayListarFiltro filtro, CancellationToken cancellationToken)
        {
            var response = await gatewaysAppService.ListarComPaginacaoAsync(filtro, cancellationToken);
            return Ok(response);
        }
    }
}
