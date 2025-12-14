using System.Data.Common;
using AccountService.Core.RepositoryInterfaces;
using AccountService.Infrastructure.Repositories;

namespace AccountService.Infrastructure;

public class UnitOfWork(AccountsDbContext context) : IUnitOfWork
{
    private IUserRepository userRepository;

    public IUserRepository UserRepository
    {
        get { return userRepository ?? (userRepository = new UserRepository(context)); }
    }

    public async Task<DbTransaction> BeginTransaction(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task SaveChanges(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
        //try
        //{
        //    await context.SaveChangesAsync();
        //}
        //catch (DbUpdateException ex)
        //{
        //    DbUpdateExceptionHandler(ex);
        //}
    }

    #region Diposable   
    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }
        disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    #endregion
}