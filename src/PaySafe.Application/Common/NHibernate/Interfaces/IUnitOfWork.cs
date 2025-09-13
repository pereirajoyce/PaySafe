namespace PaySafe.Application.Common.NHibernate.Interfaces
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Clear();
        Task CommitAsync(CancellationToken cancellationToken);
        Task RollbackAsync(CancellationToken cancellationToken);
        Task FlushAsync(CancellationToken cancellationToken);
    }
}
