using System.Text.Json;
using System.Text.Json.Serialization;
using BYT_03.entities;
using BYT_03.entities.Abstract;

namespace BYT_03.services.converters;

public class ItemConverter : JsonConverter<Item>
{
    public override Item Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        var rootElement = jsonDocument.RootElement;
        if (!rootElement.TryGetProperty("ItemTypeName", out var typeProperty))
            throw new JsonException("Unknown item type");
        Item item = null;
        switch (typeProperty.GetString())
        {
            case "PoweredComputerPart":
                item = JsonSerializer.Deserialize<PoweredComputerPart>(rootElement.GetRawText(), options)!;
                break;
            case "BatteryPoweredComputerPart":
                item = JsonSerializer.Deserialize<BatteryPoweredComputerPart>(rootElement.GetRawText(), options)!;
                break;
            case "Computer":
                item = JsonSerializer.Deserialize<Computer>(rootElement.GetRawText(), options)!;
                break;
            case "ComputerPart":
                item = JsonSerializer.Deserialize<ComputerPart>(rootElement.GetRawText(), options)!;
                break;
            default:
                Console.WriteLine("Unknown item type");
                break;
        }
        return item;
    }

    public override void Write(Utf8JsonWriter writer, Item value, JsonSerializerOptions options)
    {
        switch (value)
        {
            case PoweredComputerPart poweredPart:
                JsonSerializer.Serialize(writer, poweredPart, options);
                break;
            case BatteryPoweredComputerPart batteryPoweredPart:
                JsonSerializer.Serialize(writer, batteryPoweredPart, options);
                break;
            case Computer computer:
                JsonSerializer.Serialize(writer, computer, options);
                break;
            case ComputerPart part:
                JsonSerializer.Serialize(writer, part, options);
                break;

            default:
                throw new JsonException("Unknown item type");
        }
    }
}