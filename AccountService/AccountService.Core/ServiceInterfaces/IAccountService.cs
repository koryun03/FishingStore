namespace AccountService.Core.ServiceInterfaces;

public interface IAccountService
{
    Task<int> RegisterAsync();
}