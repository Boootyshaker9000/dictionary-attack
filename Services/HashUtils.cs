using System.Security.Cryptography;
using System.Text;

namespace PasswordCracker.Services;

public static class HashUtils
{
    public static string ComputeSha256(string input)
    {
        using var sha = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(input);
        var hashBytes = sha.ComputeHash(bytes);
        return Convert.ToHexString(hashBytes).ToLower();
    }
}