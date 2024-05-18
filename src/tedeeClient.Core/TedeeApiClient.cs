using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using tedeeClient.Core.Dtos;
using tedeeClient.Core.Enumerations;

namespace tedeeClient.Core;

public interface ITedeeClientConfiguration
{

}
public class LocalTedeeClientConfiguration : ITedeeClientConfiguration
{
	public required string BridgeIpAddress { get; init; }
	public required string ApiToken { get; init; }
	public required bool IsApiTokenEncrypted { get; init; }
}
public class CloudTedeeClientConfiguration : ITedeeClientConfiguration
{

}

public interface IRequestBuilder
{
	TedeeRequest BuildRequestForUrl(string url);
}
public class LocalRequestBuilder(
	LocalTedeeClientConfiguration configuration,
	EApiVersion apiVersion)
	: IRequestBuilder
{
	#region fields
	private readonly IApiTokenProvider _apiTokenProvider = configuration.IsApiTokenEncrypted switch
	{
		true => new Sha256ApiTokenProvider(configuration.ApiToken),
		_ => new PlainApiTokenProvider(configuration.ApiToken),
	};
	private readonly IUrlBuilder _urlBuilder = new LocalUrlBuilder(configuration.BridgeIpAddress, apiVersion);
	#endregion

	public TedeeRequest BuildRequestForUrl(string url)
	{
		var requestRoute = _urlBuilder.GetUrl(_apiTokenProvider, url);
		return new(requestRoute);
	}
}
internal interface IUrlBuilder
{
	string GetUrl(IApiTokenProvider tokenProvider, string route);
}
internal class LocalUrlBuilder(string ipAddress, EApiVersion apiVersion)
	: IUrlBuilder
{
	#region fields
	private const string HTTP = "http://";
	#endregion

	#region IUrlBuilder
	public string GetUrl(IApiTokenProvider tokenProvider, string route)
	{
		var sb = new StringBuilder();
		sb.Append(HTTP);
		sb.Append(ipAddress);
		sb.Append('/').Append(apiVersion.ToString().ToLower().Replace('_', '.'));
		sb.Append('/').Append(route);
		sb.Append("?api_token=").Append(tokenProvider.GetToken());
		return sb.ToString();
	}
	#endregion
}

internal interface IApiTokenProvider
{
	string GetToken();
}
internal class PlainApiTokenProvider(string apiToken)
	: IApiTokenProvider
{
	public string GetToken() => apiToken;
}
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
public class CloudRequestBuilder(
	CloudTedeeClientConfiguration configuration)
	: IRequestBuilder
{
	public TedeeRequest BuildRequestForUrl(string url)
	{
		throw new NotImplementedException();
	}
}
public record TedeeRequest(string Url);

public class TedeeApiClient(
	ITedeeClientConfiguration clientConfiguration,
	EApiVersion apiVersion = EApiVersion.V1_0)
{
	#region const
	private const string URL_BRIDGE = "bridge";
	private const string URL_LOCK = "lock";
	#endregion

	#region fields
	private readonly RequestExecutor _requestExecutor = new();
	private readonly IRequestBuilder _requestBuilder = clientConfiguration switch
	{
		LocalTedeeClientConfiguration localTedeeClientConfiguration => new LocalRequestBuilder(localTedeeClientConfiguration, apiVersion),
		CloudTedeeClientConfiguration cloudTedeeClientConfiguration => new CloudRequestBuilder(cloudTedeeClientConfiguration),
		_ => throw new InvalidOperationException($"Configuration of type {clientConfiguration.GetType().Name} is not supported"),
	};
	#endregion

	#region calls
	public Task<ApiResult<BridgeDto>> GetBridgeDetails()
	{
		var request = _requestBuilder.BuildRequestForUrl(URL_BRIDGE);
		return _requestExecutor.ExecuteGet<BridgeDto>(request);
	}

	public Task<ApiResult<IEnumerable<LockDto>>> GetLocks()
	{
		var request = _requestBuilder.BuildRequestForUrl(URL_LOCK);
		return _requestExecutor.ExecuteGet<IEnumerable<LockDto>>(request);
	}
	public Task<ApiResult<LockDto>> GetLockDetails(int lockId)
	{
		var request = _requestBuilder.BuildRequestForUrl($"{URL_LOCK}/{lockId}");
		return _requestExecutor.ExecuteGet<LockDto>(request);
	}
	//public Task<ApiResult> LockLock(int lockId) { }
	//public Task<ApiResult> UnlockLock(int lockId) { }
	//public Task<ApiResult> PullLock(int lockId) { }
	#endregion
}

public class RequestExecutor
{
	public async Task<ApiResult<TResult>> ExecuteGet<TResult>(TedeeRequest request)
		where TResult : class
	{
		var client = new HttpClient();
		try
		{
			var resonse = await client.GetAsync(request.Url);
			return resonse.IsSuccessStatusCode switch
			{
				true => new SuccessApiResult<TResult>
				{
					Result = JsonSerializer.Deserialize<TResult>(await resonse.Content.ReadAsStreamAsync())
				},
				_ => new ErrorApiResult<TResult>
				{
					Exception = null,
					Message = await resonse.Content.ReadAsStringAsync()
				}
			};
		}
		catch (Exception ex)
		{
			return new ErrorApiResult<TResult>
			{
				Exception = ex,
				Message = ex.Message,
			};
		}
	}
}

public class ApiResult
{
}
public class ApiResult<TResult>
{
}

public class SuccessApiResult<TResult> : ApiResult<TResult>
	where TResult : class
{
	public required TResult? Result { get; init; }
}
public class ErrorApiResult<TResult> : ApiResult<TResult>
{
	public required Exception? Exception { get; init; }
	public required string Message { get; init; }
}
