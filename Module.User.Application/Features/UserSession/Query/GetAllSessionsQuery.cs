using MediatR;
using Module.User.Application.Features.UserSession.Query.Dto;

namespace Module.User.Application.Features.UserSession.Query
{
    public record GetAllSessionsQuery : IRequest<IEnumerable<SessionResponse>>
    {

    }
}
