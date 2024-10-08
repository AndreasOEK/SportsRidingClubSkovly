using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Module.Shared.Abstractions;
using Module.User.Application.Features.UserBrowseAllSessions.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.User.Endpoints
{
    public class GetAllSessions : IEndpoint
    {
        void IEndpoint.MapEndpoint(WebApplication app)
        {
            app.MapGet("/Sessions", async (IMediator mediator) =>
            {
                return await mediator.Send(new GetAllSessionsQuery());
            }).WithTags("Session");
        }
    }
}
