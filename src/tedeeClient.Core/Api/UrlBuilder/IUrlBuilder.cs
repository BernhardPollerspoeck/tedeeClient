using tedeeClient.Core.Api.ApiTokenProvider;

namespace tedeeClient.Core.Api.UrlBuilder;

internal interface IUrlBuilder
{
    string GetUrl(IApiTokenProvider tokenProvider, string route, string? argument);
}
