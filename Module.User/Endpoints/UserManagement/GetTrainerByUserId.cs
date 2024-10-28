using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Module.Shared.Abstractions;

namespace Module.User.Endpoints.UserManagement;

public class GetTrainerByUserId : IEndpoint
{
    public void MapEndpoint(WebApplication app)
    {
        app.MapGet("User/{id}/Trainer", async ([FromRoute] Guid id, [FromServices] IMediator mediator) =>
        await mediator.Send(new GetTrainerByUserIdQuery(id)));
    }
}