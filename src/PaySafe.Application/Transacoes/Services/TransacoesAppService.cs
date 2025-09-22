using Mapster;
using PaySafe.Application.Common.NHibernate.Interfaces;
using PaySafe.Application.Transacoes.DataTransfer.Requests;
using PaySafe.Application.Transacoes.DataTransfer.Responses;
using PaySafe.Application.Transacoes.Services.Interfaces;
using PaySafe.Domain.Transacoes.Commands;
using PaySafe.Domain.Transacoes.Repositories;
using PaySafe.Domain.Transacoes.Services.Interfaces;

namespace PaySafe.Application.Transacoes.Services
{
    public class TransacoesAppService(ITransacoesService transacoesService, ITransacoesRepository transacoesRepository, IUnitOfWork unitOfWork) : ITransacoesAppService
    {
        public async Task<TransacaoResponse> InserirAsync(TransacaoInserirRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var command = request.Adapt<TransacaoCommand>();

                unitOfWork.BeginTransaction();

                var response = await transacoesService.InserirAsync(command, cancellationToken);

                await unitOfWork.CommitAsync(cancellationToken);

                return response.Adapt<TransacaoResponse>();
            }
            catch (Exception)
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                throw;
            }
        }
    }
}
