using Mapster;
using PaySafe.Application.Planos.DataTransfer.Requests;
using PaySafe.Application.Planos.DataTransfer.Responses;
using PaySafe.Application.Planos.Services.Interfaces;
using PaySafe.Domain.Planos.Commands;
using PaySafe.Domain.Planos.Services.Interfaces;

namespace PaySafe.Application.Planos.Services
{
    public class PlanosAppService(IPlanosService planosService) : IPlanosAppService
    {

        public async Task<PlanoResponse> EditarAsync(Guid guid, PlanoEditarRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var command = request.Adapt<PlanoEditarCommand>();

                var plano = await planosService.EditarAsync(guid, command, cancellationToken);

                return plano.Adapt<PlanoResponse>();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Um erro ocorreu ao tentar editar o Plano.", ex);
            }
        }

        public async Task<PlanoResponse> InserirAsync(PlanoInserirRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var command = request.Adapt<PlanoCommand>();

                var plano = await planosService.InserirAsync(command, cancellationToken);

                return plano.Adapt<PlanoResponse>();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Um erro ocorreu ao tentar inserir o Plano.", ex);
            }
        }

        public async Task<PlanoResponse> RecuperarAsync(Guid guid, CancellationToken cancellationToken)
        {
            try
            {
                var plano = await planosService.RecuperarAsync(guid, cancellationToken);

                return plano.Adapt<PlanoResponse>();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Um erro ocorreu ao tentar recuperar o Plano.", ex);
            }
        }

        public async Task ExcluirAsync(Guid guid, CancellationToken cancellationToken)
        {
            try
            {
                await planosService.ExcluirAsync(guid, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Um erro ocorreu ao tentar excluir o Plano.", ex);
            }
        }
    }
}
