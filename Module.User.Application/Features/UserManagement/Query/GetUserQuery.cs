using MediatR;
using Module.User.Application.Features.UserManagement.Query.Dto;

namespace Module.User.Application.Features.UserManagement.Query;

public sealed record GetUserQuery(Guid Id) : IRequest<UserFullResponse>;