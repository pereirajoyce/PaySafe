using Microsoft.AspNetCore.Mvc;
using PaySafe.Application.Planos.DataTransfer.Requests;
using PaySafe.Application.Planos.DataTransfer.Responses;
using PaySafe.Application.Planos.Services.Interfaces;

namespace PaySafe.API.Controllers.Planos
{
    [Route("api/planos")]
    [ApiController]
    public class PlanosController : ControllerBase
    {
        private readonly IPlanosAppService _planosAppService;

        public PlanosController(IPlanosAppService planosAppService)
        {
            _planosAppService = planosAppService;
        }

        [HttpPut("{guid}")]
        [ProducesResponseType<PlanoResponse>(StatusCodes.Status200OK)]
        public async Task<IActionResult> EditarAsync([FromRoute] Guid guid, [FromBody] PlanoEditarRequest request, CancellationToken cancellationToken)
        {
            var plano = await _planosAppService.EditarAsync(guid, request, cancellationToken);
            return Ok(plano);
        }

        [HttpPost]
        [ProducesResponseType<PlanoResponse>(StatusCodes.Status201Created)]
        public async Task<IActionResult> InserirAsync([FromBody] PlanoInserirRequest request, CancellationToken cancellationToken)
        {
            var plano = await _planosAppService.InserirAsync(request, cancellationToken);
            return Ok(plano);
        }

        [HttpGet("{guid}")]
        [ProducesResponseType<PlanoResponse>(StatusCodes.Status200OK)]
        public async Task<IActionResult> RecuperarAsync([FromRoute] Guid guid, CancellationToken cancellationToken)
        {
            var plano = await _planosAppService.RecuperarAsync(guid, cancellationToken);
            return Ok(plano);
        }

        [HttpDelete("{guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> ExcluirAsync([FromRoute] Guid guid, CancellationToken cancellationToken)
        {
            await _planosAppService.ExcluirAsync(guid, cancellationToken);
            return NoContent();
        }
    }
}
