using NHibernate;
using PaySafe.Application.Common.NHibernate.Interfaces;


namespace PaySafe.Application.Common.NHibernate
{
    public class UnitOfWork(ISession session) : IUnitOfWork, IDisposable
    {
        private ITransaction transaction;

        public void BeginTransaction()
        {
            transaction = session.BeginTransaction();
        }

        public void Clear()
        {
            session?.Clear();
        }

        public async Task CommitAsync(CancellationToken cancellationToken)
        {
            if (transaction?.IsActive ?? false)
            {
                await transaction.CommitAsync(cancellationToken);
            }
        }

        public async Task RollbackAsync(CancellationToken cancellationToken)
        {
            if (transaction?.IsActive ?? false)
            {
                await transaction.RollbackAsync(cancellationToken);
            }
        }

        public Task FlushAsync(CancellationToken cancellationToken)
        {
            return session.FlushAsync(cancellationToken);
        }

        public void Dispose()
        {
            if (transaction != null)
            {
                transaction.Dispose();
                transaction = null;
            }

            if (session != null && session.IsOpen)
            {
                session.Close();
                session = null;
            }
        }
    }
}
