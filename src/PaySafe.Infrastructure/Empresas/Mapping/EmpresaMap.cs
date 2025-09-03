using FluentNHibernate.Mapping;
using PaySafe.Domain.Empresas.Entities;

namespace PaySafe.Infrastructure.Empresas.Mapping
{
    public class EmpresaMap : ClassMap<Empresa>
    {
        public EmpresaMap()
        {
            Table("Empresas");
            Not.LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Guid).Column("GUID").Not.Nullable().Unique();
            Map(x => x.RazaoSocial).Column("RAZAO_SOCIAL").Not.Nullable();
            Map(x => x.NomeFantasia).Column("NOME_FANTASIA").Not.Nullable();
            Map(x => x.DataCriacao).Column("DATA_CRIACAO").Not.Nullable();

            Component(x => x.Cnpj, cnpj => { cnpj.Map(c => c.Numero).Column("CNPJ").Not.Nullable(); });

            References(x => x.Plano).Column("PLANO").Not.Nullable();
        }
    }
}
