using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Module.Shared.Abstractions;
using Module.User.Application.Features.UserSession.Query;

namespace Module.User.Endpoints.Session;

public class GetUserPreviousBookings : IEndpoint
{
    public void MapEndpoint(WebApplication app)
    {
        app.MapGet("User/{id}/PreviousBookings", async ([FromRoute] Guid id, [FromServices] IMediator mediator) =>
        await mediator.Send(new GetUserPreviousBookingsQuery(id)));
    }
}