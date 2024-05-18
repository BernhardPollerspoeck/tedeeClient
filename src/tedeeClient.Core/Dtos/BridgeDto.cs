using System;
using System.Text.Json;
using System.Text.Json.Serialization;

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

public class IntBoolConverter : JsonConverter<bool>
{
	public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		var value = reader.GetInt32();
		return value is 1;
	}

	public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
	{
		throw new NotImplementedException();
	}
}

public class IntTimeSpanConverter : JsonConverter<TimeSpan>
{
	public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		var value = reader.GetInt32();
		return TimeSpan.FromSeconds(value);
	}

	public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
	{
		throw new NotImplementedException();
	}
}