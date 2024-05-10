using System.Text;
using tedeeClient.Core.Api.ApiTokenProvider;
using tedeeClient.Core.Enumerations;

namespace tedeeClient.Core.Api.UrlBuilder;

internal class LocalUrlBuilder(string ipAddress, EApiVersion apiVersion)
	: IUrlBuilder
{
	private const string HTTP = "http://";
	public string GetUrl(IApiTokenProvider tokenProvider, string route, string? argument)
	{
		var sb = new StringBuilder();
		sb.Append(HTTP);
		sb.Append(ipAddress);
		sb.Append('/').Append(apiVersion.ToString().ToLower().Replace('_', '.'));
		sb.Append('/').Append(route);
		if (argument is { Length: > 0 })
		{
			sb.Append('/').Append(argument);
		}
		sb.Append("?api_token=").Append(tokenProvider.GetToken());
		return sb.ToString();
	}
}
