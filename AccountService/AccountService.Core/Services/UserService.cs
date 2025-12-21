using AccountService.Core.Common.Constants;
using AccountService.Core.Dtos;
using AccountService.Core.Entities;
using AccountService.Core.Messaging;
using AccountService.Core.RepositoryInterfaces;
using AccountService.Core.ServiceInterfaces;
using MassTransit;
using Microsoft.AspNetCore.Identity;

namespace AccountService.Core.Services;

public class UserService(UserManager<User> userManager, IUnitOfWork unitOfWork, IPublishEndpoint publishEndpoint) : IUserService
{
    public async Task<Guid> RegisterAsync(RegisterDto dto, CancellationToken cancellationToken = default)
    {
        User user = await userManager.FindByEmailAsync(dto.Email!);

        if (user is null)
        {
            throw new ArgumentException("Failed to find user");
        }

        var utcNow = DateTime.UtcNow;

        //user.PasswordHash = userManager.PasswordHasher.HashPassword(user, dto.Password);
        user.UserProfile.CreatedDate = utcNow;
        user.UserProfile.UpdatedDate = utcNow;

        await userManager.CreateAsync(user, dto.Password);
        //await userManager.CreateAsync(user);
        await userManager.AddToRoleAsync(user, UserRoles.User);

        await publishEndpoint.Publish(new UserRegisteredEvent(user.Id), cancellationToken);

        return user.Id;
    }
}