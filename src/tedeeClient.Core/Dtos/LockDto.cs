using System.Text.Json.Serialization;
using tedeeClient.Core.Enumerations;

namespace tedeeClient.Core.Dtos;

public record LockDto(
	[property: JsonPropertyName("id")] int Id,
	[property: JsonPropertyName("name")] string Name,
	[property: JsonPropertyName("type")] ELockType LockType,
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

/*
 * "type": 4,
    "id": 117339,
    "name": "Haustüre",
    "serialNumber": "24120402-000441",
    "isConnected": 1,
    "rssi": -59,
    "deviceRevision": 7,
    "version": "2.0.22519",
    "state": 2,
    "jammed": 0,
    "batteryLevel": 95,
    "isCharging": 0,
    "deviceSettings": {
      "autoLockEnabled": 0,
      "autoLockDelay": 60,
      "autoLockImplicitEnabled": 0,
      "autoLockImplicitDelay": 5,
      "pullSpringEnabled": 1,
      "pullSpringDuration": 2,
      "autoPullSpringEnabled": 0,
      "postponedLockEnabled": 1,
      "postponedLockDelay": 5,
      "buttonLockEnabled": 1,
      "buttonUnlockEnabled": 1
    }

*/