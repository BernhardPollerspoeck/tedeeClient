using tedeeClient.Core;
using tedeeClient.Core.Request;
using tedeeClient.Local.ApiTokenProvider;
using tedeeClient.Local.Builders;
using tedeeClient.Local.TedeeClientConfiguration;

namespace tedeeClient.Local.Extensions;

public static class TedeeApiClientFactoryExtensions
{
	public static ITedeeApiClient BuildLocalClient(this TedeeApiClientFactory factory, LocalTedeeClientConfiguration configuration)
	{
		IApiTokenProvider apiTokenProvider = configuration.IsApiTokenEncrypted
			? new Sha256ApiTokenProvider(configuration.ApiToken)
			: new PlainApiTokenProvider(configuration.ApiToken);
		var urlBuilder = new UrlBuilder(configuration);

		var requestBuilder = new RequestBuilder(apiTokenProvider, urlBuilder);
		var requestExecutor = new RequestExecutor();

		return new LocalTedeeApiClient(requestBuilder, requestExecutor);
	}
}
