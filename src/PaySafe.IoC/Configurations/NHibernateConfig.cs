using FluentNHibernate.Cfg;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NHibernate;
using PaySafe.Infrastructure.Usuarios.Mapping;
using ISession = NHibernate.ISession;

namespace PaySafe.IoC.Configurations
{
    internal static class NHibernateConfig
    {
        public static IServiceCollection AddNHibernate(this IServiceCollection services, IConfiguration configuration, IHostEnvironment env)
        {
            services.AddSingleton<ISessionFactory>(factory =>
            {
                return Fluently.Configure().Database(() =>
                {
                    string connectionString = configuration.GetConnectionString("MySql");

                    if (env.EnvironmentName != "Development")
                    {
                        connectionString = "*****";
                    }

                    return FluentNHibernate.Cfg.Db.MySQLConfiguration.Standard.ConnectionString(connectionString)
                            .FormatSql()
                            .ShowSql()
                            .ConnectionString(connectionString);
                })
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UsuarioMap>())
                .CurrentSessionContext("call")
                .BuildSessionFactory();
            });

            services.AddScoped<ISession>(factory =>
            {
                return factory.GetService<ISessionFactory>().OpenSession();
            });

            return services;
        }
    }
}
