using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Infrastructure;

public static class DependencyInjection
{
    /// <summary>
    /// Extension method to add infrastructure services to the dependency injection container 
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // TODO: Add services to the IoC container
        // Infrastructure service often include data access, caching or other low-level components.

        return services;
    }
}