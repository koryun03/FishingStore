using System.Security.Claims;
using System.Text;
using System.Web;
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

        var hashedPassword = userManager.PasswordHasher.HashPassword(currentUser, model.Password);

        var hashedPassword = "asdsad";
        var user = new User { Email = dto.Email, PasswordHash = hashedPassword };
        var persistUserResult = await userManager.CreateAsync(user, dto.Password);
        //var persistUserResult = await userManager.CreateAsync(user, command.Password);

        //await unitOfWork.UserRepository.  //erevi petq chi nayel(arel) 
        await unitOfWork.UserRepository.();
        await publishEndpoint.Publish(new UserRegisteredEvent(user.Id), cancellationToken);















        User currentUser = await userManager.FindByEmailAsync(dto.Email);

        if (currentUser != null)
        {
            return BadRequest("emailAlreadyExists");
        }


        currentUser.PasswordHash = userManager.PasswordHasher.HashPassword(currentUser, dto.Password);

        await userManager.CreateAsync(currentUser);
        await userManager.AddToRoleAsync(currentUser, UserRoles.User);

        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Email, currentUser.Email),
                            new Claim(ClaimTypes.Name, currentUser.FirstName),
                            new Claim(ClaimTypes.Surname,currentUser.LastName)
                        };

        await userManager.AddClaimsAsync(currentUser, claims);

        #region sendingEmail and subscribe to MailChemp

        var token = await userManager.GenerateEmailConfirmationTokenAsync(currentUser);
        var emailEncoded = HttpUtility.UrlEncode(model.Email);
        var tokenEncoded = HttpUtility.UrlEncode(token);

        var url = string.Format(configurationService.Urls().ConfirmEmail, emailEncoded, tokenEncoded);

        var templatePath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, configurationService.EmailTemplates().VerificationEmailTemplate));
        var credentials = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, configurationService.CredentialPaths().GmailApiCredentials));

        var emailVerificationTemplate = System.IO.File.ReadAllText(templatePath, Encoding.UTF8);

        await emailService.SendEmailAsync(new EmailModel()
        {
            Body = string.Format(emailVerificationTemplate, model.FirstName, url),
            From = "me",
            To = new List<string> { model.Email },
            Subject = "Your Account Has Been Created",
            Credentials = credentials,
            DisplayName = configurationService.EmailAddresses().NoReplayEmail,
            TokenPath = configurationService.TokenPaths().GmailPath
        });

        #endregion

        return Ok("confirmEmailMessage");


















    }
}