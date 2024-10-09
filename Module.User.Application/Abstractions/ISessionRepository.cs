using Module.User.Application.Features.UserBrowseAllSessions.Query.Dto;
using Module.User.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.User.Application.Abstractions
{
    public interface ISessionRepository
    {
        Task AddSessionAsync(Session session);
        Task AddBookingAsync();
        Task<Session> GetSessionById(Guid sessionId);
    }
}
