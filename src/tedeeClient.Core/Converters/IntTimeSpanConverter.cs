using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace tedeeClient.Core.Converters;

internal class IntTimeSpanConverter : JsonConverter<TimeSpan>
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