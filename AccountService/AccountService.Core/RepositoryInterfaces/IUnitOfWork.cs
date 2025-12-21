namespace AccountService.Core.RepositoryInterfaces;

public interface IUnitOfWork : IDisposable
{
    IUserRepository UserRepository { get; }
}