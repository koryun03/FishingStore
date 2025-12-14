using System.Data.Common;
using Fishing.Core.Database;

namespace AccountService.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    public Task<DbTransaction> BeginTransaction(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task SaveChanges(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
