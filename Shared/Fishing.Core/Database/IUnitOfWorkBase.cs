using System.Data.Common;

namespace Fishing.Core.Database;

public interface IUnitOfWorkBase : IDisposable
{
    Task<DbTransaction> BeginTransaction(CancellationToken cancellationToken = default);
    Task SaveChanges(CancellationToken cancellationToken = default);
}