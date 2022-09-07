using System.Data;

namespace DataModels;

public interface IUnitOfWork
{
    Task BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted, CancellationToken ct = default);
    Task CommitTransaction(CancellationToken ct = default);
    Task RollbackTransaction(CancellationToken ct = default);
    Task SaveChanges(CancellationToken ct = default);
}