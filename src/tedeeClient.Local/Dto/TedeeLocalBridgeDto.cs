using System;
using System.Text.Json.Serialization;
using tedeeClient.Local.Converters;

namespace tedeeClient.Local.Dto;

internal record TedeeLocalBridgeDto(
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
