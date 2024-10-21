using MediatR;
using Module.User.Application.Abstractions;
using Module.User.Application.Features.UserManagement.Command.Dto;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Module.User.Application.Features.UserManagement.Command;

public record LoginUserCommand(LoginUserRequest LoginUserRequest) : IRequest<string>;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, string>
{
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;

    public LoginUserCommandHandler(IUserRepository userRepository, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _configuration = configuration;
    }

    public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByEmailAsync(request.LoginUserRequest.Email);

        if (user == null || !await _userRepository.ValidateUserCredentialsAsync(request.LoginUserRequest.Email, request.LoginUserRequest.Password))
        {
            throw new UnauthorizedAccessException("Invalid credentials");
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.Id.ToString())
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
