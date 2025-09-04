using Microsoft.AspNetCore.Mvc;
using PaySafe.Application.Empresas.DataTransfer.Requests;
using PaySafe.Application.Empresas.DataTransfer.Responses;
using PaySafe.Application.Empresas.Services.Interfaces;

namespace PaySafe.API.Controllers.Empresas
{
    [Route("api/empresas")]
    [ApiController]
    public class EmpresasController : Controller
    {
        private readonly IEmpresasAppService _empresasAppService;

        public EmpresasController(IEmpresasAppService empresasAppService)
        {
            _empresasAppService = empresasAppService;
        }

        /// <summary>
        /// Cria uma nova empresa.
        /// </summary>
        [HttpPost]
        [ProducesResponseType<EmpresaResponse>(StatusCodes.Status201Created)]
        public async Task<IActionResult> InserirAsync([FromBody] EmpresaInserirRequest request, CancellationToken cancellationToken)
        {
            var empresa = await _empresasAppService.InserirAsync(request, cancellationToken);
            return Ok(empresa);
        }

        /// <summary>
        /// Recupera uma empresa pelo seu GUID.
        /// </summary>
        [HttpGet("{guid}")]
        [ProducesResponseType<EmpresaResponse>(StatusCodes.Status200OK)]
        public async Task<IActionResult> RecuperarAsync([FromRoute] Guid guid, CancellationToken cancellationToken)
        {
            var empresa = await _empresasAppService.RecuperarAsync(guid, cancellationToken);
            return Ok(empresa);
        }

        /// <summary>
        /// Atualiza os dados de uma empresa existente.
        /// </summary>
        [HttpPut("{guid}")]
        [ProducesResponseType<EmpresaResponse>(StatusCodes.Status200OK)]
        public async Task<IActionResult> EditarAsync([FromRoute] Guid guid, EmpresaEditarRequest request, CancellationToken cancellationToken)
        {
            var empresa = await _empresasAppService.EditarAsync(guid, request, cancellationToken);
            return Ok(empresa);
        }

        /// <summary>
        /// Exclui uma empresa pelo seu GUID.
        /// </summary>
        [HttpDelete("{guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> ExcluirAsync([FromRoute] Guid guid, CancellationToken cancellationToken)
        {
            await _empresasAppService.ExcluirAsync(guid, cancellationToken);
            return NoContent();
        }
    }
}