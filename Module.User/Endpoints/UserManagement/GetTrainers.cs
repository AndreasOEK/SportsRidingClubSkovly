using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Module.Shared.Abstractions;
using Module.User.Application.Features.UserManagement.Query;

namespace Module.User.Endpoints;

public class GetTrainers : IEndpoint
{
    void IEndpoint.MapEndpoint(WebApplication app)
    {
        app.MapGet("Trainer", async ([FromServices]IMediator mediator) 
                => await mediator.Send(new GetTrainersQuery()))
            .WithTags("UserManagement");
    }
}