using MediatR;
using Module.User.Application.Features.UserBrowseAllSessions.Query.Dto;

namespace Module.User.Application.Features.UserBrowseAllSessions.Query
{
    public record GetAllSessionsQuery : IRequest<IEnumerable<SessionResponse>>
    {

    }
}
