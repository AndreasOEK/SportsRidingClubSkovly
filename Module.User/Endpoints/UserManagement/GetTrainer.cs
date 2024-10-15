using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Module.Shared.Abstractions;
using Module.User.Application.Features.UserManagement.Query;
using Module.User.Application.Features.UserManagement.Query.Dto;

namespace Module.User.Endpoints.UserManagement;

public class GetTrainer : IEndpoint
{
    void IEndpoint.MapEndpoint(WebApplication app)
    {
        app.MapGet("Trainer/{id}", async ([FromRoute]Guid id, [FromServices]IMediator mediator) 
                => await mediator.Send(new GetTrainerQuery(id)))
            .WithTags("UserManagement")
            .Produces<TrainerResponse>();
    }
}