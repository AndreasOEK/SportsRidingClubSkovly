using Microsoft.Extensions.DependencyInjection;
using Module.User.Application.Extensions;
using Module.User.Application.Features.TrainerCreateSession;
using Module.User.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.User.Extensions
{
    public static class UserModule
    {
        public static IServiceCollection AddUserModule(this IServiceCollection serviceCollection)
        {

            return serviceCollection
                .AddUserModuleApplication()
                .AddUserModuleInfrastructure();
        }
    }
}
