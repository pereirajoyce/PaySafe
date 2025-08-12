using NHibernate;
using PaySafe.Domain.Common.Interfaces;

namespace PaySafe.Infrastructure.Common
{
    public class NHibernateRepository<TEntity>(ISession session) : INHibernateRepository<TEntity> where TEntity : class
    {
        private readonly ISession _session = session;

        public async Task InserirAsync(TEntity entidade, CancellationToken cancellationToken)
        {
            using var transaction = _session.BeginTransaction();

            await _session.SaveAsync(entidade, cancellationToken);

            await transaction.CommitAsync(cancellationToken);
        }

        public async Task InserirAsync(TEntity[] entidades, CancellationToken cancellationToken)
        {
            using var transaction = _session.BeginTransaction();

            foreach (var entidade in entidades)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await _session.SaveAsync(entidade, cancellationToken);
            }

            await transaction.CommitAsync(cancellationToken);
        }

        public async Task EditarAsync(TEntity entidade, CancellationToken cancellationToken)
        {
            using var transaction = _session.BeginTransaction();

            await _session.UpdateAsync(entidade, cancellationToken);

            await transaction.CommitAsync(cancellationToken);
        }

        public async Task ExcluirAsync(TEntity entidade, CancellationToken cancellationToken)
        {
            using var transaction = _session.BeginTransaction();

            await _session.DeleteAsync(entidade, cancellationToken);

            await transaction.CommitAsync(cancellationToken);
        }

        public async Task ExcluirAsync(TEntity[] entidades, CancellationToken cancellationToken)
        {
            using var transaction = _session.BeginTransaction();

            foreach (var entidade in entidades)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await _session.DeleteAsync(entidade, cancellationToken);
            }

            await transaction.CommitAsync(cancellationToken);
        }

        public async Task<TEntity> RecuperarAsync(Guid guid, CancellationToken cancellationToken)
        {
            return await _session.GetAsync<TEntity>(guid, cancellationToken);
        }
    }
}
