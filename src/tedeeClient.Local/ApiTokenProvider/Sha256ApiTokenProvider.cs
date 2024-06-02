using System;
using System.Security.Cryptography;
using System.Text;

namespace tedeeClient.Local.ApiTokenProvider;

internal class Sha256ApiTokenProvider(string apiToken)
    : IApiTokenProvider
{
    public string GetToken()
    {
        var timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        var combinedToken = $"{apiToken}{timestamp}";
        var combinedTokenData = Encoding.UTF8.GetBytes(combinedToken);

        var sha256 = SHA256.Create();
        var result = sha256.ComputeHash(combinedTokenData);
        var resultString = Encoding.UTF8.GetString(result);

        return $"{resultString}{timestamp}";
    }
}
