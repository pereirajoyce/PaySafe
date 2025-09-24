
using Microsoft.AspNetCore.Mvc;
using PaySafe.Application.Common.Consultas.DataTransfer.Responses;
using PaySafe.Application.Pagamentos.DataTramsfer.Requests;
using PaySafe.Application.Pagamentos.DataTramsfer.Responses;
using PaySafe.Application.Pagamentos.Services.Interfaces;

namespace PaySafe.API.Controllers.Pagamentos
{
    [Route("api/pagamentos")]
    [ApiController]
    public class PagamentosController(IPagamentosAppService pagamentosAppService) : ControllerBase
    {
        /// <summary>
        /// Cria um novo pagamento.
        /// </summary>
        [HttpPost]
        [ProducesResponseType<PagamentoResponse>(StatusCodes.Status201Created)]
        public async Task<IActionResult> InserirAsync([FromBody] PagamentoRequest request, CancellationToken cancellationToken)
        {
            var pagamento = await pagamentosAppService.InserirAsync(request, cancellationToken);
            return Ok(pagamento);
        }

        /// <summary>
        /// Atualiza o status de um pagament existente.
        /// </summary>
        [HttpPut("{guid}")]
        [ProducesResponseType<PagamentoResponse>(StatusCodes.Status200OK)]
        public async Task<IActionResult> EditarAsync([FromRoute] Guid guid, [FromBody] PagamentoEditarRequest request, CancellationToken cancellationToken)
        {
            var pagamento = await pagamentosAppService.EditarAsync(guid, request, cancellationToken);
            return Ok(pagamento);
        }

        /// <summary>
        /// Recupera um pagamento pelo seu GUID.
        /// </summary>
        [HttpGet("{guid}")]
        [ProducesResponseType<PagamentoResponse>(StatusCodes.Status200OK)]
        public async Task<IActionResult> RecuperarAsync([FromRoute] Guid guid, CancellationToken cancellationToken)
        {
            var plano = await pagamentosAppService.RecuperarAsync(guid, cancellationToken);
            return Ok(plano);
        }

        /// <summary>
        /// Listagem de pagamentos com paginação.
        /// </summary>
        [HttpGet()]
        [ProducesResponseType<PaginacaoResponse<PagamentoResponse>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> ListarComPaginacaoAsync([FromQuery] PagamentoListarFiltroRequest filtro, CancellationToken cancellationToken)
        {
            var response = await pagamentosAppService.ListarComPaginacaoAsync(filtro, cancellationToken);
            return Ok(response);
        }

        /// <summary>
        /// Exclui um pagamento pelo seu GUID.
        /// </summary>
        [HttpDelete("{guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> ExcluirAsync([FromRoute] Guid guid, CancellationToken cancellationToken)
        {
            await pagamentosAppService.ExcluirAsync(guid, cancellationToken);
            return NoContent();
        }
    }
}
