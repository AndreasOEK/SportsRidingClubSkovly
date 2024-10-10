using Microsoft.Extensions.DependencyInjection;

namespace Module.User.Application.Extensions;

public static class UserModuleApplicationExtension
{
    public static IServiceCollection AddUserModuleApplication(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }
}