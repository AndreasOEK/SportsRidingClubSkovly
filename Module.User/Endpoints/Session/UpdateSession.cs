﻿using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Module.Shared.Abstractions;
using Module.User.Application.Features.TrainerSession.Command;
using Module.User.Application.Features.TrainerSession.Command.Dto;

namespace Module.User.Endpoints.Session
{
    public class UpdateSession : IEndpoint
    {
        void IEndpoint.MapEndpoint(WebApplication app)
        {
            app.MapPut("/Session", async (UpdateSessionRequest updateSessionRequest, IMediator mediator) =>
            await mediator.Send(new UpdateSessionCommand(updateSessionRequest))
            ).WithTags("Session");
        }
    }
}
