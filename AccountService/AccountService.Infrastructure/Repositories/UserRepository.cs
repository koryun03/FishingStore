using AccountService.Core.RepositoryInterfaces;

namespace AccountService.Infrastructure.Repositories;

public class UserRepository(AccountsDbContext context) : IUserRepository
{

}
