using AccountService.Core.Dtos;

namespace AccountService.Core.ServiceInterfaces;

public interface IAccountService
{
    Task<Guid> RegisterAsync(RegisterDto dto, CancellationToken cancellationToken = default);
}