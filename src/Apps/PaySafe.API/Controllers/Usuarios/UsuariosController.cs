using Microsoft.AspNetCore.Mvc;
using PaySafe.Application.Common.Consultas.DataTransfer.Responses;
using PaySafe.Application.Usuarios.DataTransfer.Requests;
using PaySafe.Application.Usuarios.DataTransfer.Responses;
using PaySafe.Application.Usuarios.Services.Interfaces;

namespace PaySafe.API.Controllers.Usuarios
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuariosController(IUsuariosAppService usuariosAppService) : ControllerBase
    {

        /// <summary>
        /// Cria um novo usuário.
        /// </summary>
        [HttpPost]
        [ProducesResponseType<UsuarioResponse>(StatusCodes.Status201Created)]
        public async Task<IActionResult> InserirAsync([FromBody] UsuarioInserirRequest request, CancellationToken cancellationToken)
        {
            var usuario = await usuariosAppService.InserirAsync(request, cancellationToken);
            return Ok(usuario);
        }

        /// <summary>
        /// Atualiza os dados de um usuário existente.
        /// </summary>
        [HttpPut("{guid}")]
        [ProducesResponseType<UsuarioResponse>(StatusCodes.Status200OK)]
        public async Task<IActionResult> EditarAsync([FromRoute] Guid guid, [FromBody] UsuarioEditarRequest request, CancellationToken cancellationToken)
        {
            var usuario = await usuariosAppService.EditarAsync(guid, request, cancellationToken);
            return Ok(usuario);
        }

        /// <summary>
        /// Recupera um usuário pelo seu GUID.
        /// </summary>
        [HttpGet("{guid}")]
        [ProducesResponseType<UsuarioResponse>(StatusCodes.Status200OK)]
        public async Task<IActionResult> RecuperarAsync([FromRoute] Guid guid, CancellationToken cancellationToken)
        {
            var usuario = await usuariosAppService.RecuperarAsync(guid, cancellationToken);
            return Ok(usuario);
        }

        /// <summary>
        /// Listagem de usuários com paginação.
        /// </summary>
        [HttpGet()]
        [ProducesResponseType<PaginacaoResponse<UsuarioResponse>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> ListarComPaginacaoAsync([FromQuery] UsuarioListarFiltroRequest filtro, CancellationToken cancellationToken)
        {
            var response = await usuariosAppService.ListarComPaginacaoAsync(filtro, cancellationToken);
            return Ok(response);
        }

        /// <summary>
        /// Exclui um usuário pelo seu GUID.
        /// </summary>
        [HttpDelete("{guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> ExcluirAsync([FromRoute] Guid guid, CancellationToken cancellationToken)
        {
            await usuariosAppService.ExcluirAsync(guid, cancellationToken);
            return NoContent();
        }
    }
}
