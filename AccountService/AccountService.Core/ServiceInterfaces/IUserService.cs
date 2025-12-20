using AccountService.Core.Dtos;

namespace AccountService.Core.ServiceInterfaces;

public interface IUserService
{
    Task<Guid> RegisterAsync(RegisterDto dto, CancellationToken cancellationToken = default);
}