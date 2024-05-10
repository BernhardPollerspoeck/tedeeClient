using System.Text.Json.Serialization;
using tedeeClient.Core.Converters;
using tedeeClient.Core.Enumerations;

namespace tedeeClient.Core.Dtos;

public record LockDto(
	[property: JsonPropertyName("id")] int Id,
	[property: JsonPropertyName("name")] string Name,
	[property: JsonPropertyName("type")] ELockType Type,
	[property: JsonPropertyName("serialNumber")] string SerialNumber,
	[property:
		JsonPropertyName("isConnected"),
		JsonConverter(typeof(IntBoolConverter))]
			bool IsConnected,
	[property: JsonPropertyName("rssi")] int Rssi,
	[property: JsonPropertyName("deviceRevision")] int DeviceRevision,
	[property: JsonPropertyName("version")] string Version,
	[property: JsonPropertyName("state")] ELockState State,
	[property: 
		JsonPropertyName("jammed"),
		JsonConverter(typeof(IntBoolConverter))] 
			bool Jammed,
	[property: JsonPropertyName("batteryLevel")] byte BatteryLevel,
	[property:
		JsonPropertyName("isCharging"),
		JsonConverter(typeof(IntBoolConverter))]
			bool IsCharging,
	[property: JsonPropertyName("deviceSettings")] LockSettingDto DeviceSettings);
