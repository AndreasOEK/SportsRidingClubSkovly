using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Module.Shared.Abstractions;
using Module.User.Application.Features.TrainerSession.Command;
using Module.User.Application.Features.TrainerSession.Command.Dto;

namespace Module.User.Endpoints
{
    public class CreateSession : IEndpoint
    {
        void IEndpoint.MapEndpoint(WebApplication app)
        {
            app.MapPost("/Session", async ([FromBody] CreateSessionRequest createSessionRequest, [FromServices] IMediator mediator) =>
            {
                await mediator.Send(new CreateSessionCommand(createSessionRequest));
                return Results.Ok();
            }).WithTags("Session");
        }
    }
}
