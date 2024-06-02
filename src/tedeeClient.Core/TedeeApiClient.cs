using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;

namespace tedeeClient.Core;

public interface IBridgeItem
{

}


public sealed class TedeeApiClientFactory
{

}

public interface IMapper<TSource, TTarget>
{
	TTarget? Map(TSource? source);
}




















//public record LockDto(
//	[property: JsonPropertyName("id")] int Id,
//	[property: JsonPropertyName("name")] string Name,
//	[property: JsonPropertyName("type")] ELockType LockType,
//	[property: JsonPropertyName("serialNumber")] string SerialNumber,
//	[property:
//		JsonPropertyName("isConnected"),
//		JsonConverter(typeof(IntBoolConverter))]
//			bool IsConnected,
//	[property: JsonPropertyName("rssi")] int Rssi,
//	[property: JsonPropertyName("deviceRevision")] int DeviceRevision,
//	[property: JsonPropertyName("version")] string Version,
//	[property: JsonPropertyName("state")] ELockState State,
//	[property:
//		JsonPropertyName("jammed"),
//		JsonConverter(typeof(IntBoolConverter))]
//			bool Jammed,
//	[property: JsonPropertyName("batteryLevel")] byte BatteryLevel,
//	[property:
//		JsonPropertyName("isCharging"),
//		JsonConverter(typeof(IntBoolConverter))]
//			bool IsCharging,
//	[property: JsonPropertyName("deviceSettings")] LockSettingDto DeviceSettings);
//public record LockSettingDto(
//	[property:
//		JsonPropertyName("autoLockEnabled"),
//		JsonConverter(typeof(IntBoolConverter))]
//			bool AutoLockEnabled,
//	[property:
//		JsonPropertyName("autoLockDelay"),
//		JsonConverter(typeof(IntTimeSpanConverter))]
//			TimeSpan AutoLockDelay,
//	[property:
//		JsonPropertyName("autoLockImplicitEnabled"),
//		JsonConverter(typeof(IntBoolConverter))]
//			bool AutoLockImplicitEnabled,
//	[property:
//		JsonPropertyName("autoLockImplicitDelay"),
//		JsonConverter(typeof(IntTimeSpanConverter))]
//			TimeSpan AutoLockImplicitDelay,
//	[property:
//		JsonPropertyName("pullSpringEnabled"),
//		JsonConverter(typeof(IntBoolConverter))]
//			bool PullSpringEnabled,
//	[property:
//		JsonPropertyName("pullSpringDuration"),
//		JsonConverter(typeof(IntTimeSpanConverter))]
//			TimeSpan PullSpringDuration,
//	[property:
//		JsonPropertyName("autoPullSpringEnabled"),
//		JsonConverter(typeof(IntBoolConverter))]
//			bool AutoPullSpringEnabled,
//	[property:
//		JsonPropertyName("postponedLockEnabled"),
//		JsonConverter(typeof(IntBoolConverter))]
//			bool PostponedLockEnabled,
//	[property:
//		JsonPropertyName("postponedLockDelay"),
//		JsonConverter(typeof(IntTimeSpanConverter))]
//			TimeSpan PostponedLockDelay,
//	[property:
//		JsonPropertyName("buttonLockEnabled"),
//		JsonConverter(typeof(IntBoolConverter))]
//			bool ButtonLockEnabled,
//	[property:
//		JsonPropertyName("buttonUnlockEnabled"),
//		JsonConverter(typeof(IntBoolConverter))]
//			bool ButtonUnlockEnabled);

//public enum ELockType
//{
//    Unknown,
//    Pro = 2,
//    Go = 4,
//}
//public enum ELockState
//{
//    Uncalibrated = 0,
//    Calibration = 1,
//    Open = 2,
//    PartiallyOpen = 3,
//    Opening = 4,
//    Closing = 5,
//    Closed = 6,
//    PullSpring = 7,
//    Pulling = 8,
//    Unknown = 9,
//    Unpulling = 255,
//}
//internal class IntTimeSpanConverter : JsonConverter<TimeSpan>
//{
//	public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
//	{
//		var value = reader.GetInt32();
//		return TimeSpan.FromSeconds(value);
//	}

//	public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
//	{
//		throw new NotImplementedException();
//	}
//}
//public class IntTimeSpanConverter : JsonConverter<TimeSpan>
//{
//	public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
//	{
//		var value = reader.GetInt32();
//		return TimeSpan.FromSeconds(value);
//	}

//	public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
//	{
//		throw new NotImplementedException();
//	}
//}
//public class CloudTedeeClientConfiguration : ITedeeClientConfiguration
//{

//}






//public class CloudRequestBuilder(
//	CloudTedeeClientConfiguration configuration)
//	: IRequestBuilder
//{
//	public TedeeRequest BuildRequestForUrl(string url)
//	{
//		throw new NotImplementedException();
//	}
//}
//

//public class TedeeApiClient(
//	ITedeeClientConfiguration clientConfiguration,
//	EApiVersion apiVersion = EApiVersion.V1_0)
//{
//	private const string URL_LOCK = "lock";
//	private const string ACTION_LOCK = "lock";
//	private const string ACTION_UNLOCK = "unlock";
//	private const string ACTION_PULL = "pull";
//	#endregion

//	#region fields
//	private readonly RequestExecutor _requestExecutor = new();
//	private readonly IRequestBuilder _requestBuilder = clientConfiguration switch
//	{
//		LocalTedeeClientConfiguration localTedeeClientConfiguration => new LocalRequestBuilder(localTedeeClientConfiguration, apiVersion),
//		CloudTedeeClientConfiguration cloudTedeeClientConfiguration => new CloudRequestBuilder(cloudTedeeClientConfiguration),
//		_ => throw new InvalidOperationException($"Configuration of type {clientConfiguration.GetType().Name} is not supported"),
//	};
//	#endregion

//	#region calls
//	public Task<ApiResult<IEnumerable<LockDto>>> GetLocks()
//	{
//		var request = _requestBuilder.BuildRequestForUrl(URL_LOCK);
//		return _requestExecutor.ExecuteGet<IEnumerable<LockDto>>(request);
//	}
//	public Task<ApiResult<LockDto>> GetLockDetails(int lockId)
//	{
//		var request = _requestBuilder.BuildRequestForUrl($"{URL_LOCK}/{lockId}");
//		return _requestExecutor.ExecuteGet<LockDto>(request);
//	}
//	public Task<ApiResult> LockLock(int lockId)
//	{
//		var request = _requestBuilder.BuildRequestForUrl($"{URL_LOCK}/{lockId}/{ACTION_LOCK}");
//		return _requestExecutor.ExecutePost(request);
//	}

//	public Task<ApiResult> UnlockLock(int lockId)
//	{
//		var request = _requestBuilder.BuildRequestForUrl($"{URL_LOCK}/{lockId}/{ACTION_UNLOCK}");
//		return _requestExecutor.ExecutePost(request);
//	}
//	public Task<ApiResult> PullLock(int lockId)
//	{
//		var request = _requestBuilder.BuildRequestForUrl($"{URL_LOCK}/{lockId}/{ACTION_PULL}");
//		return _requestExecutor.ExecutePost(request);
//	}
//	#endregion
//}




