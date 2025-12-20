using AccountService.Core.Entities;
using Fishing.Core.Database;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace AccountService.Infrastructure;

public class AccountsDbContext : IdentityDbContext<User, Role, Guid>
{
    private readonly ApplicationContextOptions options;
    public AccountsDbContext(DbContextOptions<AccountsDbContext> options, IOptions<ApplicationContextOptions> o)
           : base(options)
    {
        this.options = o?.Value;
    }

    public IQueryable<User> ReadUsers => Set<User>().AsQueryable().AsNoTracking();

    public IQueryable<Role> ReadRoles => Set<Role>().AsQueryable().AsNoTracking();

    public bool SoftDelete { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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