using MediatR;
using Module.User.Application.Features.UserManagement.Query.Dto;

namespace Module.User.Application.Features.UserSession.Query;

public record GetUserPreviousBookingsQuery(Guid Id) : IRequest<IEnumerable<UserBookingFullResponse>>;