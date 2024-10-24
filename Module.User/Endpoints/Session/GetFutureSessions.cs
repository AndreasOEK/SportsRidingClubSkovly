using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Module.Shared.Abstractions;
using Module.User.Application.Features.UserSession.Query;

namespace Module.User.Endpoints.Session;

public class GetFutureSessions : IEndpoint
{
    public void MapEndpoint(WebApplication app)
    {
        app.MapGet("/Sessions/InFuture", async ([FromServices] IMediator mediator) =>
            await mediator.Send(new GetFutureSessionsQuery())
        ).WithName("Session");
    }
}