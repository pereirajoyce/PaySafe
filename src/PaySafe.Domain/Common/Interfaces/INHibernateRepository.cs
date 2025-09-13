using PaySafe.Domain.Common;

namespace PaySafe.Domain.Common.Interfaces
{
    public interface INHibernateRepository<TEntity> where TEntity : class
    {
        Task InserirAsync(TEntity entidade, CancellationToken cancellationToken);
        Task InserirAsync(TEntity[] entidades, CancellationToken cancellationToken);
        Task EditarAsync(TEntity entidade, CancellationToken cancellationToken);
        Task ExcluirAsync(TEntity entidade, CancellationToken cancellationToken);
        Task ExcluirAsync(TEntity[] entidades, CancellationToken cancellationToken);
        Task<TEntity> RecuperarAsync(Guid guid, CancellationToken cancellationToken);
        Task<TEntity[]> ListarAsync(TEntity filtros, CancellationToken cancellationToken);
        Task<(TEntity[] resultado, int contagemTotal)> ListarComPaginacaoAsync<TFiltro>(TFiltro filtros, int pg, int qtd, string ordenacaoPor, string ordenacao, CancellationToken cancellationToken);
    }
}
