using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NHibernate;
using PaySafe.Infrastructure.Usuarios.Mapping;

namespace PaySafe.IoC.Configurations.NHibernate
{
    public static class NHibernateConfig
    {
        public static IServiceCollection AddNHibernate(this IServiceCollection services, IConfiguration configuration, IHostEnvironment env)
        {
            services.AddSingleton<ISessionFactory>(sp =>
            {
                var cs = env.IsDevelopment()
                    ? configuration.GetConnectionString("MySql")
                    : "*****";

                return Fluently.Configure()
                    .Database(MySQLConfiguration.Standard
                        .ConnectionString(cs)
                        .ShowSql()
                        .FormatSql())
                    .Mappings(m =>
                    {
                        m.FluentMappings.AddFromAssemblyOf<UsuarioMap>();
                    })
                    .BuildSessionFactory();
            });

            services.AddScoped<ISession>(sp =>
                sp.GetRequiredService<ISessionFactory>().OpenSession());

            return services;
        }
    }
}
