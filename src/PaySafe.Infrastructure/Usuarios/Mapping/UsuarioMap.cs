using FluentNHibernate.Mapping;
using PaySafe.Domain.Usuarios.Entities;

namespace PaySafe.Infrastructure.Usuarios.Mapping
{
    public class UsuarioMap : ClassMap<Usuario>
    {
        public UsuarioMap()
        {
            Table("USUARIO");
            Id(x => x.Id).GeneratedBy.Identity().Column("ID");
            Map(x => x.Guid).Column("GUID").Not.Nullable();
            Map(x => x.Nome).Column("NOME").Not.Nullable().Length(100);
            Map(x => x.Sobrenome).Column("SOBRENOME").Not.Nullable().Length(100);
            Map(x => x.Cpf.Numero).Column("CPF").Not.Nullable().Length(14);
            Map(x => x.Email.Endereco).Column("EMAIL").Not.Nullable();
            Map(x => x.Telefone).Column("TELEFONE").Nullable();
            Map(x => x.Excluido).Column("EXCLUIDO").Not.Nullable();

            References(x => x.Empresa).Columns("EMPRESA");
        }
    }
}
