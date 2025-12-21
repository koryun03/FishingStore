using AccountService.Core.Entities;
using AccountService.Infrastructure.EntityConfigurations;
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
    public DbSet<GuestUser> GuestUsers { get; set; }
    public DbSet<UserDevice> UserDevices { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new UserConfiguration());

        if (options.SoftDelete)
        {
            builder.ApplySoftDeleteQueryFilter();
        }
    }

    //public async Task<IDbContextTransaction> BeginTransactionAsync()
    //{
    //    if (_currentTransaction != null) return null;

    //    _currentTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

    //    return _currentTransaction;
    //}

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var utcNow = DateTime.UtcNow;

        foreach (var entry in ChangeTracker.Entries<IAuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = utcNow;
                    entry.Entity.UpdatedDate = utcNow;
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedDate = utcNow;
                    break;
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}