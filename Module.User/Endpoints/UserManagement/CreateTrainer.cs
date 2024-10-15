using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Module.Shared.Abstractions;
using Module.User.Application.Features.UserManagement.Command;
using Module.User.Application.Features.UserManagement.Command.Dto;

namespace Module.User.Endpoints.UserManagement;

public class CreateTrainer : IEndpoint
{
    void IEndpoint.MapEndpoint(WebApplication app)
    {
        app.MapPost("User/{id}/Trainer", async ([FromRoute] Guid id, [FromServices] IMediator mediator) =>
        {
            var request = new CreateTrainerRequest(id);
            await mediator.Send(new CreateTrainerCommand(request));
        }).WithTags("UserManagement");
    }
}