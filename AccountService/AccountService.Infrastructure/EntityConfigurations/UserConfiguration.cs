using AccountService.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountService.Infrastructure.EntityConfigurations;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(k => k.Id);
        builder.HasOne(p => p.UserProfile)
            .WithOne(p => p.User);
        builder.Property(p => p.Id).ValueGeneratedOnAdd();
        builder.Property(p => p.FirstName)
            .HasMaxLength(64)
            .IsUnicode(true);
        builder.Property(p => p.LastName)
            .HasMaxLength(64)
            .IsUnicode(true);
        builder.Property(p => p.HasBraintreeAccount)
            .HasDefaultValue(false);

        builder.HasIndex(k => k.IsBlocked)
        .IsClustered(false).IncludeProperties("Email");
    }
}
