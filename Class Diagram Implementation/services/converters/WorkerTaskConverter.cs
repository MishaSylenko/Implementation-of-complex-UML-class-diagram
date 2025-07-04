using System.Text.Json;
using System.Text.Json.Serialization;
using BYT_03.entities;

namespace BYT_03.services;


public class WorkerTaskConverter : JsonConverter<WorkerTask>
{
    public override WorkerTask Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        var rootElement = jsonDocument.RootElement;

        return JsonSerializer.Deserialize<WorkerTask>(rootElement.GetRawText())!;
    }

    public override void Write(Utf8JsonWriter writer, WorkerTask value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value);
    }
}