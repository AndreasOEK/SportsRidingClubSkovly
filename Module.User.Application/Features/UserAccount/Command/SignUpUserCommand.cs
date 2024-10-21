using MediatR;
using Module.User.Application.Abstractions;
using Module.User.Application.Features.UserAccount.Command.Dto;

namespace Module.User.Application.Features.UserAccount.Command;

public record SignUpUserCommand(SignUpUserRequest Request) : IRequest<UserAccountResponse>;

public class SignUpUserCommandHandler : IRequestHandler<SignUpUserCommand, UserAccountResponse>
{
    private readonly IUserAccountRepository _userAccountRepository;

    public SignUpUserCommandHandler(IUserAccountRepository userAccountRepository)
    {
        _userAccountRepository = userAccountRepository;
    }

    public async Task<UserAccountResponse> Handle(SignUpUserCommand request, CancellationToken cancellationToken)
        => await _userAccountRepository.SignUpUser(request.Request);
}