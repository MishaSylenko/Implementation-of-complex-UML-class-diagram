using System.Text.Json;
using System.Text.Json.Serialization;
using BYT_03.entities;

namespace BYT_03.services.converters;

public class PaymentsConverter : JsonConverter<Payment>
{
    public override Payment Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        var rootElement = jsonDocument.RootElement;

        return JsonSerializer.Deserialize<Payment>(rootElement.GetRawText())!;    }

    public override void Write(Utf8JsonWriter writer, Payment value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value);
    }
}