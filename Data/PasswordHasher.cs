using System.Security.Cryptography;
using System.Text;

namespace DataDriven.Data;

/// <summary>
/// Utility for hashing and verifying passwords using PBKDF2 algorithm.
/// </summary>
public static class PasswordHasher
{
    private const int SaltSize = 16;
    private const int HashSize = 32;
    private const int Iterations = 10000;
    private const char Delimiter = ':';

    /// <summary>
    /// Hashes a password using PBKDF2 with a randomly generated salt.
    /// Returns format: "salt:hash" (base64 encoded)
    /// </summary>
    public static string HashPassword(string password)
    {
        using var rng = RandomNumberGenerator.Create();
        byte[] salt = new byte[SaltSize];
        rng.GetBytes(salt);

        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
            password,
            salt,
            Iterations,
            HashAlgorithmName.SHA256,
            HashSize);

        string saltBase64 = Convert.ToBase64String(salt);
        string hashBase64 = Convert.ToBase64String(hash);

        return $"{saltBase64}{Delimiter}{hashBase64}";
    }

    /// <summary>
    /// Verifies a password against a hash created by HashPassword().
    /// </summary>
    public static bool VerifyPassword(string password, string hash)
    {
        try
        {
            string[] parts = hash.Split(Delimiter);
            if (parts.Length != 2)
                return false;

            string saltBase64 = parts[0];
            string hashBase64 = parts[1];

            byte[] salt = Convert.FromBase64String(saltBase64);
            byte[] storedHash = Convert.FromBase64String(hashBase64);

            byte[] computedHash = Rfc2898DeriveBytes.Pbkdf2(
                password,
                salt,
                Iterations,
                HashAlgorithmName.SHA256,
                HashSize);

            return CryptographicOperations.FixedTimeEquals(computedHash, storedHash);
        }
        catch
        {
            return false;
        }
    }
}
