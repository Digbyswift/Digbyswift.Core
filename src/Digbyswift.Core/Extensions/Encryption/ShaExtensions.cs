using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace Digbyswift.Core.Extensions.Encryption;

public static class ShaExtensions
{
    public static string ToSHA1Hash(this string text)
    {
#pragma warning disable S4790
        using var algorithm = SHA1.Create();
#pragma warning restore S4790
        return algorithm.GenerateHashString(text);
    }

    public static string ToSHA256Hash(this string text)
    {
        using var algorithm = SHA256.Create();
        return algorithm.GenerateHashString(text);
    }

    public static string ToSHA384Hash(this string text)
    {
        using var algorithm = SHA384.Create();
        return algorithm.GenerateHashString(text);
    }

    public static string ToSHA512Hash(this string text)
    {
        using var algorithm = SHA512.Create();
        return algorithm.GenerateHashString(text);
    }

    private static string GenerateHashString(this HashAlgorithm algorithm, string text)
    {
        algorithm.ComputeHash(Encoding.UTF8.GetBytes(text));
        var result = algorithm.Hash;
        return result != null
            ? String.Join(String.Empty, result.Select(x => x.ToString("x2", CultureInfo.InvariantCulture)))
            : throw new ArgumentException("Unable to create hash", nameof(text));
    }
}
