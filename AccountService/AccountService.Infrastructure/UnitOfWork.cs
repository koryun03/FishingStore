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