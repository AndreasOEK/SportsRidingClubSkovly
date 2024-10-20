namespace Module.User.Infrastructure.Authentication;

public class JwtOptions
{
    public string Issuer { get; init; } = "SkovlyAPI";
    public string Audience { get; init; } = "SkovlyWeb";
    public string SecretKey { get; init; } = "SuperSecretKey123.";
}