using AccountService.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AccountService.Infrastructure;

public class AccountsDbContext : IdentityDbContext<User, Role, Guid>
{
    public AccountsDbContext(DbContextOptions<AccountsDbContext> options) : base(options)
    {

    }

    public IQueryable<User> ReadUsers => Set<User>().AsQueryable().AsNoTracking();

    public IQueryable<Role> ReadRoles => Set<Role>().AsQueryable().AsNoTracking();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }

    //public async Task<IDbContextTransaction> BeginTransactionAsync()
    //{
    //    if (_currentTransaction != null) return null;

    //    _currentTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

    //    return _currentTransaction;
    //}

}