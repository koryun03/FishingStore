using AccountService.Core.Dtos;
using AccountService.Core.Entities;
using AccountService.Core.Messaging;
using AccountService.Core.RepositoryInterfaces;
using AccountService.Core.ServiceInterfaces;
using MassTransit;
using Microsoft.AspNetCore.Identity;

namespace AccountService.Core.Services;

public class AccountService(UserManager<User> userManager, IUnitOfWork unitOfWork, IPublishEndpoint publishEndpoint) : IAccountService
{
    public async Task<Guid> RegisterAsync(RegisterDto dto, CancellationToken cancellationToken = default)
    {
        var hashedPassword = "asdsad";
        var user = new User { Email = dto.Email, PasswordHash = hashedPassword };
        var persistUserResult = await userManager.CreateAsync(user, dto.Password);
        //var persistUserResult = await userManager.CreateAsync(user, command.Password);

        //await unitOfWork.UserRepository.  //erevi petq chi nayel(sachkovic em copy arel) 
        await unitOfWork.SaveChanges();
        await publishEndpoint.Publish(new UserRegisteredEvent(user.Id), cancellationToken);
    }
}