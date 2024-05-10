using System.Collections.Generic;
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
	private const string URL_LOCK = "lock";
	private const string COMMAND_LOCK = "lock";
	private const string COMMAND_UNLOCK = "unlock";
	private const string COMMAND_PULL = "pull";
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
			[URL_BRIDGE]);
		return _requestExecutor.ExecuteGet<BridgeDto>(url);
	}
	public Task<ApiResult<IEnumerable<LockDto>>> GetLocks()
	{
		var url = _urlBuilder.GetUrl(
			_tokenProvider,
			[URL_LOCK]);
		return _requestExecutor.ExecuteGet<IEnumerable<LockDto>>(url);
	}
	public Task<ApiResult<LockDto>> GetLockDetails(int lockId)
	{
		var url = _urlBuilder.GetUrl(
				_tokenProvider,
				[URL_LOCK, lockId.ToString()]);
		return _requestExecutor.ExecuteGet<LockDto>(url);
	}
	public Task<ApiResult> LockLock(int lockId)
	{
		var url = _urlBuilder.GetUrl(
			_tokenProvider,
			[URL_LOCK, lockId.ToString(), COMMAND_LOCK]);
		return _requestExecutor.ExecutePost(url);
	}
	public Task<ApiResult> UnlockLock(int lockId)
	{
		var url = _urlBuilder.GetUrl(
				_tokenProvider,
				[URL_LOCK, lockId.ToString(), COMMAND_UNLOCK]);
		return _requestExecutor.ExecutePost(url);
	}
	public Task<ApiResult> PullLock(int lockId)
	{
		var url = _urlBuilder.GetUrl(
					_tokenProvider,
					[URL_LOCK, lockId.ToString(), COMMAND_PULL]);
		return _requestExecutor.ExecutePost(url);
	}
	#endregion
}
