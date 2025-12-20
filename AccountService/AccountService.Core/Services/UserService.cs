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
        var user = await userManager.FindByEmailAsync(dto.Email!);

        if (user is null)
        {
            throw new ArgumentException("Failed to find user");
        }

        var hashedPassword = userManager.PasswordHasher.HashPassword(currentUser, model.Password);

        var hashedPassword = "asdsad";
        var user = new User { Email = dto.Email, PasswordHash = hashedPassword };
        var persistUserResult = await userManager.CreateAsync(user, dto.Password);
        //var persistUserResult = await userManager.CreateAsync(user, command.Password);

        //await unitOfWork.UserRepository.  //erevi petq chi nayel(arel) 
        await unitOfWork.SaveChanges();
        await publishEndpoint.Publish(new UserRegisteredEvent(user.Id), cancellationToken);
    }
}