using Microsoft.AspNetCore.Mvc;
using PaySafe.Application.Common.Consultas.DataTransfer.Responses;
using PaySafe.Application.Planos.DataTransfer.Requests;
using PaySafe.Application.Transacoes.DataTransfer.Requests;
using PaySafe.Application.Transacoes.DataTransfer.Responses;
using PaySafe.Application.Transacoes.Services.Interfaces;

namespace PaySafe.API.Controllers.Transacoes
{
    [Route("api/transacoes")]
    [ApiController]
    public class TransacoesController(ITransacoesAppService transacoesAppService) : ControllerBase
    {
        /// <summary>
        /// Cria uma nova transacao.
        /// </summary>
        [HttpPost]
        [ProducesResponseType<TransacaoResponse>(StatusCodes.Status201Created)]
        public async Task<IActionResult> InserirAsync([FromBody] TransacaoInserirRequest request, CancellationToken cancellationToken)
        {
            var transacao = await transacoesAppService.InserirAsync(request, cancellationToken);
            return Ok(transacao);
        }

        /// <summary>
        /// Atualiza os dados de uma transacao existente.
        /// </summary>
        [HttpPut("{guid}")]
        [ProducesResponseType<TransacaoResponse>(StatusCodes.Status200OK)]
        public async Task<IActionResult> EditarAsync([FromRoute] Guid guid, [FromBody] TransacaoEditarRequest request, CancellationToken cancellationToken)
        {
            var transacao = await transacoesAppService.EditarAsync(guid, request, cancellationToken);
            return Ok(transacao);
        }

        /// <summary>
        /// Recupera uma transacao pelo seu GUID.
        /// </summary>
        [HttpGet("{guid}")]
        [ProducesResponseType<TransacaoResponse>(StatusCodes.Status200OK)]
        public async Task<IActionResult> RecuperarAsync([FromRoute] Guid guid, CancellationToken cancellationToken)
        {
            var transacao = await transacoesAppService.ValidarAsync(guid, cancellationToken);
            return Ok(transacao);
        }

        /// <summary>
        /// Listagem de transacoes com paginação.
        /// </summary>
        [HttpGet()]
        [ProducesResponseType<PaginacaoResponse<TransacaoResponse>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> ListarComPaginacaoAsync([FromQuery] TransacaoListarFiltroRequest filtro, CancellationToken cancellationToken)
        {
            var transacoes = await transacoesAppService.ListarComPaginacaoAsync(filtro, cancellationToken);
            return Ok(transacoes);
        }

        /// <summary>
        /// Exclui uma transacao pelo seu GUID.
        /// </summary>
        [HttpDelete("{guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> ExcluirAsync([FromRoute] Guid guid, CancellationToken cancellationToken)
        {
            await transacoesAppService.ExcluirAsync(guid, cancellationToken);
            return NoContent();
        }
    }
}
