using tedeeClient.Core.Request;
using tedeeClient.Local.ApiTokenProvider;

namespace tedeeClient.Local.Builders;

internal class RequestBuilder(
    IApiTokenProvider apiTokenProvider,
    UrlBuilder urlBuilder)
{
    public TedeeRequest BuildRequestForUrl(string url)
    {
        var requestRoute = urlBuilder.GetUrl(apiTokenProvider, url);
        return new(requestRoute);
    }
}
