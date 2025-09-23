using Mapster;
using PaySafe.Application.Transacoes.DataTransfer.Requests;
using PaySafe.Application.Transacoes.DataTransfer.Responses;
using PaySafe.Domain.Transacoes.Commands;
using PaySafe.Domain.Transacoes.Entities;

namespace PaySafe.Application.Transacoes.Profiles.TransacaoProfile
{
    public class TransacaoProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Transacao, TransacaoResponse>();
            config.NewConfig<TransacaoInserirRequest, TransacaoCommand>();
            config.NewConfig<TransacaoEditarRequest, TransacaoEditarCommand>();
        }
    }
}
