using NHibernate;
using NHibernate.Criterion;
using PaySafe.Domain.Common;
using PaySafe.Domain.Common.Interfaces;

namespace PaySafe.Infrastructure.Common
{
    public class NHibernateRepository<TEntity>(ISession session) : INHibernateRepository<TEntity> where TEntity : class
    {
        private readonly ISession _session = session;

        public async Task InserirAsync(TEntity entidade, CancellationToken cancellationToken)
        {
            await _session.SaveAsync(entidade, cancellationToken);
        }

        public async Task InserirAsync(TEntity[] entidades, CancellationToken cancellationToken)
        {
            var tamanhoLote = 20;
            for (int i = 0; i < entidades.Length; i += tamanhoLote)
            {
                var lote = entidades.Skip(i).Take(tamanhoLote);
                foreach (var entidade in lote)
                {
                    await _session.SaveAsync(entidade, cancellationToken);
                }
            }
        }

        public async Task EditarAsync(TEntity entidade, CancellationToken cancellationToken)
        {
            await _session.UpdateAsync(entidade, cancellationToken);
        }

        public async Task ExcluirAsync(TEntity entidade, CancellationToken cancellationToken)
        {
            await _session.DeleteAsync(entidade, cancellationToken);
        }

        public async Task ExcluirAsync(TEntity[] entidades, CancellationToken cancellationToken)
        {
            var tamanhoLote = 20;
            for (int i = 0; i < entidades.Length; i += tamanhoLote)
            {

                var lote = entidades.Skip(i).Take(tamanhoLote);
                foreach (var entidade in lote)
                {
                    await _session.DeleteAsync(entidade, cancellationToken);
                }
            }
        }

        public async Task<TEntity> RecuperarAsync(Guid guid, CancellationToken cancellationToken)
        {
            return await _session.QueryOver<TEntity>()
                .Where(Restrictions.Eq("Guid", guid))
                .SingleOrDefaultAsync(cancellationToken);
        }

        public async Task<TEntity[]> ListarAsync(TEntity filtros, CancellationToken cancellationToken)
        {
            var query = _session.QueryOver<TEntity>();

            var propriedades = typeof(TEntity).GetProperties();
            foreach (var propriedade in propriedades)
            {
                var valor = propriedade.GetValue(filtros);
                if (valor != null)
                {
                    query = query.Where(Restrictions.Eq(propriedade.Name, valor));
                }
            }

            var resultados = await query.ListAsync(cancellationToken);
            return [.. resultados];
        }

        public async Task<(TEntity[] resultado, int contagemTotal)> ListarComPaginacaoAsync<TFiltro>(TFiltro filtros, int pg, int qtd, string ordenacaoPor, string ordenacao, CancellationToken cancellationToken)
        {
            var query = _session.QueryOver<TEntity>();

            AplicarFiltros(query, filtros);

            AplicarOrdenacao(query, ordenacaoPor, ordenacao);

            var contagemTotal = await query.ToRowCountQuery().SingleOrDefaultAsync<int>(cancellationToken);

            var resultados = await query
                .Skip((pg - 1) * qtd)
                .Take(qtd)
                .ListAsync(cancellationToken);

            return (resultados.ToArray(), contagemTotal);
        }

        private static void AplicarFiltros<TFiltro>(IQueryOver<TEntity, TEntity> query, TFiltro filtros)
        {
            var propriedadesExcluidas = new HashSet<string>
            {
                nameof(PaginacaoConsulta.Pg),
                nameof(PaginacaoConsulta.Qtd),
                nameof(PaginacaoConsulta.OrdenacaoPor),
                nameof(PaginacaoConsulta.Ordenacao)
            };

            foreach (var propriedade in typeof(TFiltro).GetProperties())
            {
                if (propriedadesExcluidas.Contains(propriedade.Name)) continue;
                
                var valor = propriedade.GetValue(filtros);
                if (valor != null)
                {
                    query.Where(Restrictions.Eq(propriedade.Name, valor));
                }
            }
        }

        private static void AplicarOrdenacao(IQueryOver<TEntity, TEntity> query, string ordenacaoPor, string ordenacao)
        {
            if (string.IsNullOrEmpty(ordenacaoPor)) return;

            var orderBy = Projections.Property(ordenacaoPor);

            _ = string.Equals(ordenacao, "asc", StringComparison.OrdinalIgnoreCase) ? query.OrderBy(orderBy).Asc() : query.OrderBy(orderBy).Desc();
        }
    }
}