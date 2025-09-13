using Microsoft.AspNetCore.Mvc;
using PaySafe.Application.Common.Consultas.DataTransfer.Responses;
using PaySafe.Application.Planos.DataTransfer.Requests;
using PaySafe.Application.Planos.DataTransfer.Responses;
using PaySafe.Application.Planos.Services.Interfaces;

namespace PaySafe.API.Controllers.Planos
{
    [Route("api/planos")]
    [ApiController]
    public class PlanosController(IPlanosAppService planosAppService) : ControllerBase
    {
        /// <summary>
        /// Cria um novo plano.
        /// </summary>
        [HttpPost]
        [ProducesResponseType<PlanoResponse>(StatusCodes.Status201Created)]
        public async Task<IActionResult> InserirAsync([FromBody] PlanoInserirRequest request, CancellationToken cancellationToken)
        {
            var plano = await planosAppService.InserirAsync(request, cancellationToken);
            return Ok(plano);
        }

        /// <summary>
        /// Atualiza os dados de um plano existente.
        /// </summary>
        [HttpPut("{guid}")]
        [ProducesResponseType<PlanoResponse>(StatusCodes.Status200OK)]
        public async Task<IActionResult> EditarAsync([FromRoute] Guid guid, [FromBody] PlanoEditarRequest request, CancellationToken cancellationToken)
        {
            var plano = await planosAppService.EditarAsync(guid, request, cancellationToken);
            return Ok(plano);
        }

        /// <summary>
        /// Recupera um plano pelo seu GUID.
        /// </summary>
        [HttpGet("{guid}")]
        [ProducesResponseType<PlanoResponse>(StatusCodes.Status200OK)]
        public async Task<IActionResult> RecuperarAsync([FromRoute] Guid guid, CancellationToken cancellationToken)
        {
            var plano = await planosAppService.RecuperarAsync(guid, cancellationToken);
            return Ok(plano);
        }

        /// <summary>
        /// Listagem de planos com paginação.
        /// </summary>
        [HttpGet()]
        [ProducesResponseType<PaginacaoResponse<PlanoResponse>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> ListarComPaginacaoAsync([FromQuery] PlanoListarFiltroRequest filtro, CancellationToken cancellationToken)
        {
            var response = await planosAppService.ListarComPaginacaoAsync(filtro, cancellationToken);
            return Ok(response);
        }

        /// <summary>
        /// Exclui um plano pelo seu GUID.
        /// </summary>
        [HttpDelete("{guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> ExcluirAsync([FromRoute] Guid guid, CancellationToken cancellationToken)
        {
            await planosAppService.ExcluirAsync(guid, cancellationToken);
            return NoContent();
        }
    }
}