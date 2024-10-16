using MediatR;
using Module.User.Application.Abstractions;
using SportsRidingClubSkovly.Web.DTO.Account;

namespace Module.User.Application.Features.UserAccount.Command;

public record AuthenticateUserCommand(AuthenticateUserRequest Request) : IRequest<UserAccountResponse>;

public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, UserAccountResponse>
{
    private readonly IUserAccountRepository _userAccountRepository;

    public AuthenticateUserCommandHandler(IUserAccountRepository userAccountRepository)
    {
        _userAccountRepository = userAccountRepository;
    }
    
    public async Task<UserAccountResponse> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
    {
        return await _userAccountRepository.AuthenticateUser(request.Request);
    }
}