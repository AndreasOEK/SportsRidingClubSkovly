using Microsoft.Extensions.DependencyInjection;
using Module.User.Infrastructure.DbContexts;

namespace Module.User.Infrastructure.Extensions;

public static class UserModuleInfrastructureExtension
{
    public static IServiceCollection AddUserModuleInfrastructure(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContext<UserDbContext>();

        return serviceCollection;
    }
}