namespace tedeeClient.Core.Api.ApiTokenProvider;

internal class PlainApiTokenProvider(string apiToken)
    : IApiTokenProvider
{
    public string GetToken() => apiToken;
}
