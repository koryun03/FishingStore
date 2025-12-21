using System.Security.Claims;
using AccountService.Core.Entities;
using Microsoft.Extensions.Options;

namespace AccountService.Infrastructure.Providers;

public class JwtTokenProvider : ITokenProvider
{
    private readonly IRolesRepository _rolesRepository;
    private readonly AccountsDbContext _accountContext;
    private readonly IRsaKeyProvider _rsaKeyProvider;
    private readonly AuthOptions _authOptions;

    public JwtTokenProvider(
        IOptions<AuthOptions> options,
        IRolesRepository rolesRepository,
        AccountsDbContext accountContext,
        IRsaKeyProvider rsaKeyProvider)
    {
        _rolesRepository = rolesRepository;
        _accountContext = accountContext;
        _rsaKeyProvider = rsaKeyProvider;
        _authOptions = options.Value;
    }

    public async Task<JwtTokenResult> GenerateAccessToken(User user, CancellationToken cancellationToken)
    {

    }

    public async Task<Guid> GenerateRefreshToken(User user, CancellationToken cancellationToken)
    {
    }

    public async Task<IReadOnlyList<Claim>> GetUserClaims(
        string jwtToken, CancellationToken cancellationToken)
    {

    }
}