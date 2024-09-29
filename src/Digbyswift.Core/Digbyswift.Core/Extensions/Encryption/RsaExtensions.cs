using System;
using System.Security.Cryptography;
using System.Text;

namespace Digbyswift.Core.Extensions.Encryption;

public static class RsaExtensions
{
    /// <summary>
    /// Most basic RSA encryption with no public/private key.
    /// </summary>
    public static string RSAEncrypt(this string text)
    {
        var bytesToEncrypt = Encoding.UTF8.GetBytes(text);

        using var rsaProvider = new RSACryptoServiceProvider(2048);
        rsaProvider.ImportParameters(rsaProvider.ExportParameters(false));
        return Convert.ToBase64String(rsaProvider.Encrypt(bytesToEncrypt, RSAEncryptionPadding.OaepSHA256));
    }

    /// <summary>
    /// RSA encryption requiring a 2048 bit public/private key.
    /// </summary>
    public static string RSAEncrypt(this string text, string publicKeyXml)
    {
        var bytesToEncrypt = Encoding.UTF8.GetBytes(text);

        using var rsaProvider = new RSACryptoServiceProvider(2048);
        rsaProvider.FromXmlString(publicKeyXml);

        return Convert.ToBase64String(rsaProvider.Encrypt(bytesToEncrypt, RSAEncryptionPadding.OaepSHA256));
    }

    /// <summary>
    /// Most basic RSA decryption with no public/private key.
    /// </summary>
    public static string RSADecrypt(this string encryptedText)
    {
        var encryptedBytes = Convert.FromBase64String(encryptedText);

        using var rsaProvider = new RSACryptoServiceProvider(2048);
        rsaProvider.ImportParameters(rsaProvider.ExportParameters(true));

        return Encoding.UTF8.GetString(rsaProvider.Decrypt(encryptedBytes, RSAEncryptionPadding.OaepSHA256));
    }

    /// <summary>
    /// RSA decryption requiring a 2048 bit public/private key.
    /// </summary>
    public static string RSADecrypt(this string encryptedText, string privateKeyXml)
    {
        var encryptedBytes = Convert.FromBase64String(encryptedText);

        using var rsaProvider = new RSACryptoServiceProvider(2048);
        rsaProvider.FromXmlString(privateKeyXml);

        return Encoding.UTF8.GetString(rsaProvider.Decrypt(encryptedBytes, RSAEncryptionPadding.OaepSHA256));
    }
}
