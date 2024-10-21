using MediatR;
using Module.Shared.Abstractions;
using Module.User.Application.Abstractions;
using Module.User.Application.Features.UserManagement.Command.Dto;

namespace Module.User.Application.Features.UserManagement.Command;

public record CreateUserCommand(CreateUserRequest Request) : IRequest<Task>, ITransactionalCommand;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Task>
{
    private readonly IUserRepository _userRepository;

    public CreateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<Task> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var userRequest = request.Request;
        
        // Create
        var user = Domain.Entity.User.Create(userRequest.FirstName, userRequest.LastName, userRequest.Phone, userRequest.Email, userRequest.Password);
        
        // Do & Save
        await _userRepository.CreateUserAsync(user);

        return Task.CompletedTask;
    }
}
