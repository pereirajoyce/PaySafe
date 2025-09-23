using FluentNHibernate.Mapping;
using PaySafe.CrossCutting.Enums;
using PaySafe.Domain.Transacoes.Entities;

namespace PaySafe.Infrastructure.Transacoes.Mappings
{
    public class TransacaoMap : ClassMap<Transacao>
    {
        public TransacaoMap()
        {
            Table("TRANSACAO");
            Not.LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity().Column("ID");
            Map(x => x.Guid).Column("GUID").Not.Nullable();
            Map(x => x.PrecoTotal).Column("PRECO_TOTAL").Not.Nullable();
            Map(x => x.Taxa).Column("TAXA").Not.Nullable();
            Map(x => x.Frete).Column("FRETE").Not.Nullable();
            Map(x => x.Itens).Column("ITENS").Not.Nullable();
            Map(x => x.Status).Column("STATUS").Not.Nullable().CustomType<StatusEnum>();

            References(x => x.Empresa).Column("EMPRESA_ID").Not.Nullable();
        }
    }
}
