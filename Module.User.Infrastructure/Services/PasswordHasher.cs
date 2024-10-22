using System.Security.Cryptography;
using Module.User.Application.Abstractions;
using Module.User.Application.Abstractions.Authentication;

namespace Module.User.Infrastructure.Services;

public class PasswordHasher : IPasswordHasher
{
    private const int SaltSize = 16;
    private const int HashSize = 32;
    private const int Iterations = 100000;

    private readonly HashAlgorithmName Algorithm = HashAlgorithmName.SHA512;

    string IPasswordHasher.Hash(string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, Algorithm, HashSize);
        
        return $"{Convert.ToHexString(hash)}-{Convert.ToHexString(salt)}";
    }

    public bool Verify(string requestPassword, string? accountPassword)
    {
        var parts = accountPassword.Split('-');
        
        var hash = Convert.FromHexString(parts[0]);
        var salt = Convert.FromHexString(parts[1]);

        var inputHash = Rfc2898DeriveBytes.Pbkdf2(requestPassword, salt, Iterations, Algorithm, HashSize);

        // return hash.SequenceEqual(inputHash); // Attackers can see how long it takes to compare and then find the correct hash
        return CryptographicOperations.FixedTimeEquals(hash, inputHash);
    }
}