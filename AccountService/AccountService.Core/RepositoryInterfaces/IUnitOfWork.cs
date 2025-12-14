using Fishing.Core.Database;

namespace AccountService.Core.RepositoryInterfaces;

public interface IUnitOfWork : IUnitOfWorkBase
{
    IUserRepository UserRepository { get; }
}