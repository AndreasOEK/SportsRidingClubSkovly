using MediatR;
using Module.User.Application.Features.UserSession.Query.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.User.Application.Features.UserSession.Query
{
    public record GetSessionByIdQuery(Guid sessionId) : IRequest<SessionResponse>
    {
    }
}
