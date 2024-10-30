using MediatR;
using Module.User.Application.Features.UserManagement.Query.Dto;

namespace Module.User.Endpoints.UserManagement;

public record GetTrainerByUserIdQuery(Guid Id) : IRequest<CreateSessionTrainerResponse>;