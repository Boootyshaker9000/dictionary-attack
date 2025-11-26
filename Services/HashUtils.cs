using System.Security.Cryptography;
using System.Text;

namespace PasswordCracker.Services;

/// <summary>
/// Class for encrypting plaintext passwords using SHA256
/// </summary>
public static class HashUtils
{
    /// <summary>
    /// Encrypts the password and returns it's hash value
    /// </summary>
    /// <param name="password">plaintext password</param>
    /// <returns>Hash value of password</returns>
    public static string ComputeSha256(string password)
    {
        using var sha = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(password);
        var hashBytes = sha.ComputeHash(bytes);
        return Convert.ToHexString(hashBytes).ToLower();
    }
}