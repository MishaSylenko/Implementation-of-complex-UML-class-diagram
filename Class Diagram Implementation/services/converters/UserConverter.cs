using System.Text.Json;
using System.Text.Json.Serialization;
using BYT_03.entities;
using BYT_03.entities.Abstract;

namespace BYT_03.services.converters;

public class UserConverter : JsonConverter<User>
{
    public override User Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        var rootElement = jsonDocument.RootElement;

        if (!rootElement.TryGetProperty("UserTypeName", out var userTypeNameProperty))
            throw new JsonException("Unknown user type");

        User user = null;

        switch (userTypeNameProperty.GetString())
        {
            case "Client":
                user = JsonSerializer.Deserialize<Client>(rootElement.GetRawText(), options)!;
                break;

            // case "ServiceMan":
            //     user = JsonSerializer.Deserialize<ServiceMan>(rootElement.GetRawText(), options)!;
            //     break;
            //
            // case "InfolineOperator":
            //     user = JsonSerializer.Deserialize<InfolineOperator>(rootElement.GetRawText(), options)!;
            //     break;

            case "Worker":
                user = JsonSerializer.Deserialize<Worker>(rootElement.GetRawText(), options)!;
                break;

            default:
                Console.WriteLine("Unknown user type");
                break;
        }

        return user;
    }

    public override void Write(Utf8JsonWriter writer, User value, JsonSerializerOptions options)
    {
        switch (value)
        {
            case Client client:
                JsonSerializer.Serialize(writer, client, options);
                break;

            // case InfolineOperator infolineOperator:
            //     JsonSerializer.Serialize(writer, infolineOperator, options);
            //     break;
            //
            // case ServiceMan serviceMan:
            //     JsonSerializer.Serialize(writer, serviceMan, options);
            //     break;

            case Worker worker:
                JsonSerializer.Serialize(writer, worker, options);
                break;

            default:
                throw new JsonException("Unknown user type");
        }
    }
}