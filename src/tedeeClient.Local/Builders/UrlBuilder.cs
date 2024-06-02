using System.Text;
using tedeeClient.Local.ApiTokenProvider;
using tedeeClient.Local.TedeeClientConfiguration;

namespace tedeeClient.Local.Builders;

internal class UrlBuilder(LocalTedeeClientConfiguration configuration)
{
    public string GetUrl(IApiTokenProvider tokenProvider, string route)
    {
        var sb = new StringBuilder();
        sb.Append("http://");
        sb.Append(configuration.BridgeIpAddress);
        sb.Append('/').Append(configuration.ApiVersion.ToString().ToLower().Replace('_', '.'));
        sb.Append('/').Append(route);
        sb.Append("?api_token=").Append(tokenProvider.GetToken());
        return sb.ToString();
    }
}
