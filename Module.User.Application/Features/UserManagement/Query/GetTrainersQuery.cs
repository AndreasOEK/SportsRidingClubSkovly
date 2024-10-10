using MediatR;
using Module.User.Application.Features.UserManagement.Query.Dto;

namespace Module.User.Application.Features.UserManagement.Query;

public record GetTrainersQuery() : IRequest<IEnumerable<TrainerResponse>>;