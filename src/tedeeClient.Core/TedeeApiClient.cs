using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using tedeeClient.Core.Api.ApiTokenProvider;
using tedeeClient.Core.Api.UrlBuilder;
using tedeeClient.Core.ApiModels;
using tedeeClient.Core.Dtos;
using tedeeClient.Core.Enumerations;

namespace tedeeClient.Core;

public class TedeeApiClient(
	string ipAddress,
	//TODO: implement:EConnectionMode connectionMode,
	string apiToken,
	bool encryptToken,
	EApiVersion apiVersion = EApiVersion.V1_0)
{
	#region const
	private const string URL_BRIDGE = "bridge";
	#endregion

	#region fields
	private readonly IApiTokenProvider _tokenProvider = encryptToken
		? new Sha256ApiTokenProvider(apiToken)
		: new PlainApiTokenProvider(apiToken);
	private readonly IUrlBuilder _urlBuilder = new LocalUrlBuilder(ipAddress, apiVersion);
	private readonly RequestExecutor _requestExecutor = new();
	#endregion

	#region calls
	public Task<ApiResult<BridgeDto>> GetBridgeDetails()
	{
		var url = _urlBuilder.GetUrl(
			_tokenProvider,
			URL_BRIDGE,
			null);
		return _requestExecutor.ExecuteGet<BridgeDto>(url);
	}
	//public Task<ApiResult<IEnumerable<LockDto>>> GetLocks() { }
	//public Task<ApiResult<LockDto>> GetLockDetails(int lockId) { }
	//public Task<ApiResult> LockLock(int lockId) { }
	//public Task<ApiResult> UnlockLock(int lockId) { }
	//public Task<ApiResult> PullLock(int lockId) { }
	#endregion
}

public class RequestExecutor
{
	public async Task<ApiResult<TResult>> ExecuteGet<TResult>(string url)
		where TResult : class
	{
		var client = new HttpClient();
		try
		{
			var resonse = await client.GetAsync(url);
			return new ApiResult<TResult>
			{
				Success = resonse.IsSuccessStatusCode,
				Result = resonse.IsSuccessStatusCode
					? JsonSerializer.Deserialize<TResult>(await resonse.Content.ReadAsStreamAsync())
					: null,
				Message = resonse.IsSuccessStatusCode
					? null
					: await resonse.Content.ReadAsStringAsync()
			};
		}
		catch (Exception ex)
		{
			return new ApiResult<TResult>
			{
				Success = false,
				Result = default,
				Message = ex.Message,
			};
		}
	}
}