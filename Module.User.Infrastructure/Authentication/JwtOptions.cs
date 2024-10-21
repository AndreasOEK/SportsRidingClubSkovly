namespace Module.User.Infrastructure.Authentication;

public class JwtOptions
{
    public string Issuer { get; init; } = "Skovly.API";
    public string Audience { get; init; } = "Skovly.Web";
    public string SecretKey { get; init; } = "YourSuperDuperSecretKeyThatNoOneCanGuess";
}