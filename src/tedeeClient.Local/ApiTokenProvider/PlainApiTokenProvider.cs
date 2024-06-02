namespace tedeeClient.Local.ApiTokenProvider;

internal class PlainApiTokenProvider(string apiToken)
    : IApiTokenProvider
{
    public string GetToken() => apiToken;
}
