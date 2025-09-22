using FluentNHibernate.Mapping;
using PaySafe.Domain.Planos.Entities;

namespace PaySafe.Infrastructure.Planos.Mapping
{
    public class PlanoMap : ClassMap<Plano>
    {
        public PlanoMap()
        {
            Table("PLANO");
            Not.LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity().Column("ID");
            Map(x => x.Guid).Column("GUID").Not.Nullable();
            Map(x => x.Nome).Column("NOME").Not.Nullable().Length(100);
            Map(x => x.Mensalidade).Column("MENSALIDADE").Not.Nullable();
            Map(x => x.Volume).Column("VOLUME").Not.Nullable();
            Map(x => x.ValorExcedente).Column("VALOR_EXCEDENTE").Not.Nullable();
            Map(x => x.MaximoUsuarios).Column("MAXIMO_USUARIOS").Not.Nullable();
            Map(x => x.MaximoGrupos).Column("MAXIMO_GRUPOS").Not.Nullable();
        }
    }
}
