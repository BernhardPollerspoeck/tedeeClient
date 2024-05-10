using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace tedeeClient.Core.Converters;
internal class IntBoolConverter : JsonConverter<bool>
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
