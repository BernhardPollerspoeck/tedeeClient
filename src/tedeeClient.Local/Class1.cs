using System;
using System.Threading.Tasks;
using tedeeClient.Core;
using tedeeClient.Core.Request;
using tedeeClient.Core.Result;
using tedeeClient.Local.Builders;
using tedeeClient.Local.Dto;

namespace tedeeClient.Local;

public static class MapperKeys
{
	public static class Local
	{
		public const string BRIDGE_DETAIL = $"{nameof(MapperKeys)}.{nameof(Local)}.{nameof(BRIDGE_DETAIL)}";
	}
}


internal class LocalTedeeApiClient(
	RequestBuilder requestBuilder,
	RequestExecutor requestExecutor,
	IResponseMapperProvider responseMapperProvider)
	: ITedeeApiClient
{
	#region const
	private const string URL_BRIDGE = "bridge";
	#endregion

	#region ITedeeApiClient
	public async Task<ApiResult<IBridgeItem>> GetBridgeDetails()
	{
		var request = requestBuilder.BuildRequestForUrl(URL_BRIDGE);
		var data = await requestExecutor.ExecuteGet<TedeeLocalBridgeDto>(request);
		var mapper = responseMapperProvider.GetMapper(MapperKeys.Local.BRIDGE_DETAIL);
		return mapper.Map<IBridgeItem>(data);

		return data switch
		{
			ErrorApiResult<TedeeLocalBridgeDto> errorData => new ErrorApiResult<IBridgeItem>()
			{
				Exception = errorData.Exception,
				Message = errorData.Message,
			},
			SuccessApiResult<TedeeLocalBridgeDto> successData => new SuccessApiResult<IBridgeItem>()
			{
				Result = new BridgeMapper().Map(successData.Result),
			},
			_ => new ErrorApiResult<IBridgeItem>()
			{
				Exception = null,
				Message = "Result could not be processed",
			}
		};

	}
	#endregion
}


internal class BridgeMapper : IMapper<TedeeLocalBridgeDto, IBridgeItem>
{
	public IBridgeItem? Map(TedeeLocalBridgeDto? source)
	{
		return source switch
		{
			not null => new LocalBridgeItem(
				source.Name,
				source.CurrentTime,
				source.SerialNumber,
				source.Ssid,
				source.IsConnected,
				source.Version,
				source.WifiVersion),
			_ => null,
		};
	}
}




public record LocalBridgeItem(
	string Name,
	DateTime CurrentTime,
	string SerialNumber,
	string Ssid,
	bool IsConnected,
	string Version,
	string WifiVersion)
	: IBridgeItem;