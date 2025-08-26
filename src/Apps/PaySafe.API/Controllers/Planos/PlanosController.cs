using Microsoft.AspNetCore.Mvc;
using PaySafe.Application.Planos.DataTransfer.Requests;
using PaySafe.Application.Planos.DataTransfer.Responses;
using PaySafe.Application.Planos.Services.Interfaces;

namespace PaySafe.API.Controllers.Planos
{
    [Route("api/planos")]
    [ApiController]
    public class PlanosController(IPlanosAppService planosAppService) : ControllerBase
    {
        [HttpPut("{guid}")]
        [ProducesResponseType<PlanoResponse>(StatusCodes.Status200OK)]
        public async Task<IActionResult> EditarAsync([FromRoute] Guid guid, [FromBody] PlanoEditarRequest request, CancellationToken cancellationToken)
        {
            var plano = await planosAppService.EditarAsync(guid, request, cancellationToken);
            return Ok(plano);
        }

        [HttpPost]
        [ProducesResponseType<PlanoResponse>(StatusCodes.Status201Created)]
        public async Task<IActionResult> InserirAsync([FromBody] PlanoInserirRequest request, CancellationToken cancellationToken)
        {
            var plano = await planosAppService.InserirAsync(request, cancellationToken);
            return CreatedAtAction(nameof(RecuperarAsync), new { guid = plano.Guid }, plano);
        }

        [HttpGet("{guid}")]
        [ProducesResponseType<PlanoResponse>(StatusCodes.Status200OK)]
        public async Task<IActionResult> RecuperarAsync([FromRoute] Guid guid, CancellationToken cancellationToken)
        {
            var plano = await planosAppService.RecuperarAsync(guid, cancellationToken);
            return Ok(plano);
        }

        [HttpDelete("{guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> ExcluirAsync([FromRoute] Guid guid, CancellationToken cancellationToken)
        {
            await planosAppService.ExcluirAsync(guid, cancellationToken);
            return NoContent();
        }
    }
}
