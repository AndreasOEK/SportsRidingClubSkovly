using MediatR;
using Module.User.Application.Abstractions;
using Module.User.Application.Features.UserAccount.Command.Dto;

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
        var authenticateRequest = request.Request;
        var account = await _userAccountRepository.GetAccountByUsername(authenticateRequest.Username);

        if (account is null)
            throw new Exception("Account was not found");

        var verified = _passwordHasher.Verify(authenticateRequest.Password, account.PasswordHash);

        if (!verified)
            throw new Exception("Password is incorrect");

        var isTrainer = await _userRepository.IsUserTrainer(account.User.Id);

        return new UserAccountResponse(
            account.User.Id,
            account.User.FirstName,
            account.User.LastName,
            account.User.Email,
            isTrainer);
    }
}