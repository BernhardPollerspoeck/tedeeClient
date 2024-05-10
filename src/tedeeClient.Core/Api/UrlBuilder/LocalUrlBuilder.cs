using System.Text;
using tedeeClient.Core.Api.ApiTokenProvider;
using tedeeClient.Core.Enumerations;

namespace tedeeClient.Core.Api.UrlBuilder;

internal class LocalUrlBuilder(string ipAddress, EApiVersion apiVersion)
	: IUrlBuilder
{
	private const string HTTP = "http://";
	public string GetUrl(IApiTokenProvider tokenProvider, string[] route)
	{
		var sb = new StringBuilder();
		sb.Append(HTTP);
		sb.Append(ipAddress);
		sb.Append('/').Append(apiVersion.ToString().ToLower().Replace('_', '.'));
		foreach (var segment in route)
		{
			sb.Append('/').Append(segment);
		}
		sb.Append("?api_token=").Append(tokenProvider.GetToken());
		return sb.ToString();
	}
}
