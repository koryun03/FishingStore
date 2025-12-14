using AccountService.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AccountService.Infrastructure;

//public class AccountsDbContext : DbContext
//public class AccountsDbContext : IdentityDbContext<User, Role, Guid>, IAccountsReadDbContext
public class AccountsDbContext : IdentityDbContext<User, Role, Guid>
{


}