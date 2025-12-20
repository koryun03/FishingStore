using AccountService.Core.ServiceInterfaces;
using AccountService.Core.Services;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;

namespace AccountService.Core;

public static class CoreServiceCollectionExtensions
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();

        return services;
    }

    public static IServiceCollection AddMapper(this IServiceCollection services)
    {
        //AccountMapper.RegisterMappings()

        TypeAdapterConfig.GlobalSettings.Compiler = exp => exp.Compile();

        services.AddSingleton(TypeAdapterConfig.GlobalSettings);
        services.AddScoped<IMapper, Mapper>();
        return services;
    }
}