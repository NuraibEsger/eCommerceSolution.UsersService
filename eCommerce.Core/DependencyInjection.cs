using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Core;

public static class DependencyInjection
{
    /// <summary>
    /// Extension method to add core services to the dependency injection container 
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        // TODO: Add services to the IoC container
        // Core service often include data access, caching or other low-level components.

        services.AddTransient<IUsersService, UserService>();
        return services;
    }
}