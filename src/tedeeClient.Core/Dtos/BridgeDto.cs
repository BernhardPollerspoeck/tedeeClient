using System;
using System.Text.Json.Serialization;
using tedeeClient.Core.Converters;

namespace tedeeClient.Core.Dtos;

public record BridgeDto(
	[property: JsonPropertyName("name")] string Name,
	[property: JsonPropertyName("currentTime")] DateTime CurrentTime,
	[property: JsonPropertyName("serialNumber")] string SerialNumber,
	[property: JsonPropertyName("ssid")] string Ssid,
	[property:
		JsonPropertyName("isConnected"),
		JsonConverter(typeof(IntBoolConverter))]
			bool IsConnected,
	[property: JsonPropertyName("version")] string Version,
	[property: JsonPropertyName("wifiVersion")] string WifiVersion);