using FluentNHibernate.Mapping;
using PaySafe.CrossCutting.Enums;
using PaySafe.Domain.Pagamentos.Entities;
using PaySafe.Domain.Transacoes.Enums;

namespace PaySafe.Infrastructure.Pagamentos.Mappings
{
    public class PagamentoMap : ClassMap<Pagamento>
    {
        public PagamentoMap()
        {
            Table("TRANSACAO_PAGAMENTO");
            Not.LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity().Column("ID");
            Map(x => x.Guid).Column("GUID").Not.Nullable();
            Map(x => x.Metodo).Column("METODO").Not.Nullable().CustomType<MetodoPagamentoEnum>();
            Map(x => x.Valor).Column("VALOR").Not.Nullable();
            Map(x => x.Status).Column("STATUS").Not.Nullable().CustomType<StatusEnum>();
            Map(x => x.DataCriacao).Column("DATA_CRIACAO").Not.Nullable();

            References(x => x.Transacao).Column("TRANSACAO_ID").Not.Nullable();
        }
    }
}
