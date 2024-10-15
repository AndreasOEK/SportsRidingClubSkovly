using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Module.Shared.Abstractions;
using Module.User.Application.Features.UserSession.Query;

namespace Module.User.Endpoints.Session
{
    class GetSessionById : IEndpoint
    {
        void IEndpoint.MapEndpoint(WebApplication app)
        {
            app.MapGet("/Session/{sessionId}", async (Guid sessionId, IMediator mediator) =>
            {
                return await mediator.Send(new GetSessionByIdQuery(sessionId));
            }).WithTags("Session");
        }
    }
}
