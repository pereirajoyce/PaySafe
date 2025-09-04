using Microsoft.AspNetCore.Mvc;
using PaySafe.Application.Usuarios.DataTransfer.Requests;
using PaySafe.Application.Usuarios.DataTransfer.Responses;
using PaySafe.Application.Usuarios.Services.Interfaces;

namespace PaySafe.API.Controllers.Usuarios
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuariosController(IUsuariosAppService usuariosAppService) : Controller
    {
        [HttpPost()]
        [ProducesResponseType<UsuarioResponse>(StatusCodes.Status201Created)]
        public async Task<IActionResult> InserirAsync([FromBody] UsuarioInserirRequest request, CancellationToken cancellationToken)
        {
            var usuario = await usuariosAppService.InserirAsync(request, cancellationToken);
            return Ok(usuario);
        }

        [HttpPut("{guid}")]
        [ProducesResponseType<UsuarioResponse>(StatusCodes.Status200OK)]
        public async Task<IActionResult> EditarAsync([FromRoute] Guid guid, [FromBody] UsuarioEditarRequest request, CancellationToken cancellationToken)
        {
            var usuario = await usuariosAppService.EditarAsync(guid, request, cancellationToken);
            return Ok(usuario);
        }

        [HttpGet("{guid}")]
        [ProducesResponseType<UsuarioResponse>(StatusCodes.Status200OK)]
        public async Task<IActionResult> RecuperarAsync([FromRoute] Guid guid, CancellationToken cancellationToken)
        {
            var usuario = await usuariosAppService.RecuperarAsync(guid, cancellationToken);
            return Ok(usuario);
        }

        [HttpDelete()]
        [ProducesResponseType<UsuarioResponse>(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> ExcluirAsync([FromRoute] Guid guid, CancellationToken cancellationToken)
        {
            await usuariosAppService.ExcluirAsync(guid, cancellationToken);
            return NoContent();
        }
    }
}
