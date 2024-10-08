using MediatR;
using Module.User.Application.Abstractions;
using Module.User.Application.Features.UserBrowseAllSessions.Query.Dto;

namespace Module.User.Application.Features.UserBrowseAllSessions.Query
{
    public record GetAllSessionsQuery : IRequest<IEnumerable<SessionResponse>>
    {

    }

    public class GetAllSessionsQueryHandler : IRequestHandler<GetAllSessionsQuery, IEnumerable<SessionResponse>>
    {
        private readonly ISessionRepository _sessionRepository;

        public GetAllSessionsQueryHandler(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        async Task<IEnumerable<SessionResponse>> IRequestHandler<GetAllSessionsQuery, IEnumerable<SessionResponse>>.Handle(
            GetAllSessionsQuery request,
            CancellationToken cancellationToken)
        {
            return await _sessionRepository.GetAllSessions();
        }
    }
}
