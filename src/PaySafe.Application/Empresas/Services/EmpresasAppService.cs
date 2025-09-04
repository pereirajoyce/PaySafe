using Mapster;
using PaySafe.Application.Empresas.DataTransfer.Requests;
using PaySafe.Application.Empresas.DataTransfer.Responses;
using PaySafe.Application.Empresas.Services.Interfaces;
using PaySafe.Domain.Empresas.Commands;
using PaySafe.Domain.Empresas.Services.Interfaces;

namespace PaySafe.Application.Empresas.Services
{
    public class EmpresasAppService(IEmpresasService empresasService) : IEmpresasAppService
    {
        public async Task<EmpresaResponse> RecuperarAsync(Guid guid, CancellationToken cancellationToken)
        {
            try
            {
                var response = await empresasService.RecuperarAsync(guid, cancellationToken);

                return response.Adapt<EmpresaResponse>();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Um erro ocorreu ao tentar recuperar a empresa.", ex);
            }
        }

        public async Task<EmpresaResponse> InserirAsync(EmpresaInserirRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var command = request.Adapt<EmpresaCommand>();

                var response = await empresasService.InserirAsync(command, cancellationToken);

                return response.Adapt<EmpresaResponse>();

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Um erro ocorreu ao tentar criar uma empresa.", ex);
            }
        }

        public async Task<EmpresaResponse> EditarAsync(Guid guid, EmpresaEditarRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var command = request.Adapt<EmpresaEditarCommand>();

                var response = await empresasService.EditarAsync(guid, command, cancellationToken);

                return response.Adapt<EmpresaResponse>();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Um erro ocorreu ao tentar editar uma empresa.", ex);
            }
        }

        public async Task ExcluirAsync(Guid guid, CancellationToken cancellationToken)
        {
            try
            {
                await empresasService.ExcluirAsync(guid, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Um erro ocorreu ao tentar excluir a empresa.", ex);
            }
        }
    }
}
