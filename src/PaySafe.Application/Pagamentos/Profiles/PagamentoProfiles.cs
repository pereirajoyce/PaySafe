using Mapster;
using PaySafe.Application.Pagamentos.DataTramsfer.Requests;
using PaySafe.Application.Pagamentos.DataTramsfer.Responses;
using PaySafe.Domain.Pagamentos.Commands;
using PaySafe.Domain.Pagamentos.Entities;

namespace PaySafe.Application.Pagamentos.Profiles
{
    public class PagamentoProfiles : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Pagamento, PagamentoResponse>()
                .Map(dest => dest.TransacaoGuid, src => src.Transacao.Guid);

            config.NewConfig<PagamentoRequest, PagamentoCommand>();
            config.NewConfig<PagamentoEditarRequest, PagamentoEditarCommand>();
        }
    }
}
