using tedeeClient.Core.TedeeClientConfiguration;

namespace tedeeClient.Local.TedeeClientConfiguration;

public class LocalTedeeClientConfiguration
    : BaseTedeeClientConfiguration
    , ITedeeClientConfiguration
{
    public required string BridgeIpAddress { get; init; }
    public required string ApiToken { get; init; }
    public required bool IsApiTokenEncrypted { get; init; }
}
