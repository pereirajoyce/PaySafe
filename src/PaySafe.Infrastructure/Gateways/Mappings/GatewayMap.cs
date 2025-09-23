using FluentNHibernate.Mapping;
using PaySafe.Domain.Gateways.Entities;
using PaySafe.Domain.Gateways.Enums;

namespace PaySafe.Infrastructure.Gateways.Mappings
{
    public class GatewayMap : ClassMap<Gateway>
    {
        public GatewayMap()
        {
            Table("GATEWAY");
            Not.LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Guid).Column("GUID").Not.Nullable().Unique();
            Map(x => x.Servico).Column("SERVICO").Not.Nullable().CustomType<ServicoEnum>();
            Map(x => x.Prioridade).Column("PRIORIDADE").Not.Nullable();

            References(x => x.Empresa).Column("EMPRESA_ID").Not.Nullable();
        }
    }
}
