using Microsoft.AspNetCore.Mvc;
using PaySafe.Application.Common;
using PaySafe.Application.Usuarios.DataTransfer.Requests;
using PaySafe.Application.Usuarios.DataTransfer.Responses;
using PaySafe.Application.Usuarios.Services.Interfaces;

namespace PaySafe.API.Controllers.Usuarios
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuariosController : Controller
    {
        private readonly IUsuariosAppService _usuariosAppService;

        public UsuariosController(IUsuariosAppService usuariosAppService)
        {
            _usuariosAppService = usuariosAppService;
        }

        /// <summary>
        /// Cria um novo usuário.
        /// </summary>
        [HttpPost]
        [ProducesResponseType<UsuarioResponse>(StatusCodes.Status201Created)]
        public async Task<IActionResult> InserirAsync([FromBody] UsuarioInserirRequest request, CancellationToken cancellationToken)
        {
            var usuario = await _usuariosAppService.InserirAsync(request, cancellationToken);
            return Ok(usuario);
        }

        /// <summary>
        /// Atualiza os dados de um usuário existente.
        /// </summary>
        [HttpPut("{guid}")]
        [ProducesResponseType<UsuarioResponse>(StatusCodes.Status200OK)]
        public async Task<IActionResult> EditarAsync([FromRoute] Guid guid, [FromBody] UsuarioEditarRequest request, CancellationToken cancellationToken)
        {
            var usuario = await _usuariosAppService.EditarAsync(guid, request, cancellationToken);
            return Ok(usuario);
        }

        /// <summary>
        /// Recupera um usuário pelo seu GUID.
        /// </summary>
        [HttpGet("{guid}")]
        [ProducesResponseType<UsuarioResponse>(StatusCodes.Status200OK)]
        public async Task<IActionResult> RecuperarAsync([FromRoute] Guid guid, CancellationToken cancellationToken)
        {
            var usuario = await _usuariosAppService.RecuperarAsync(guid, cancellationToken);
            return Ok(usuario);
        }

        /// <summary>
        /// Exclui um usuário pelo seu GUID.
        /// </summary>
        [HttpDelete("{guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> ExcluirAsync([FromRoute] Guid guid, CancellationToken cancellationToken)
        {
            await _usuariosAppService.ExcluirAsync(guid, cancellationToken);
            return NoContent();
        }

        /// <summary>
        /// Listagem de usuários com paginação.
        /// </summary>
        [HttpGet()]
        [ProducesResponseType<PaginacaoResponse<UsuarioResponse>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> ListarComPaginacaoAsync([FromQuery] UsuarioListarFiltro filtro, CancellationToken cancellationToken)
        {
            var response = await _usuariosAppService.ListarComPaginacaoAsync(filtro, cancellationToken);
            return Ok(response);
        }
    }
}
