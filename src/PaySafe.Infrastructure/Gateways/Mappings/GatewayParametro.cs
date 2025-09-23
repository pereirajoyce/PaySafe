using FluentNHibernate.Mapping;
using PaySafe.Domain.Gateways.Entities;
using PaySafe.Domain.Gateways.Enums;

namespace PaySafe.Infrastructure.Gateways.Mappings
{
    public class GatewayParametroMap : ClassMap<GatewayParametro>
    {
        public GatewayParametroMap()
        {
            Table("GATEWAY_PARAMETRO");
            Not.LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Guid).Column("GUID").Not.Nullable().Unique();
            Map(x => x.Chave).Column("CHAVE").Not.Nullable();
            Map(x => x.Valor).Column("VALOR").Not.Nullable();

            References(x => x.Gateway).Column("GATEWAY_ID").Not.Nullable();
        }
    }
}
