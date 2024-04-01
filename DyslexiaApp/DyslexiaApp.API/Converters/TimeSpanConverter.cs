using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DyslexiaApp.API.Converter;

public class TimeSpanConverter : JsonConverter<TimeSpan>
{
    public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.StartObject)
        {
            Console.WriteLine("bbbb");
            // Implement logic to handle the object and extract TimeSpan
            // This is an example, you will need to adjust it based on the actual structure
            using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
            {
                JsonElement root = doc.RootElement;

                // Assuming the object has a suitable property to construct TimeSpan
                // For example, if it's an object with hours, minutes, and seconds
                int hours = root.GetProperty("hours").GetInt32();
                int minutes = root.GetProperty("minutes").GetInt32();
                int seconds = root.GetProperty("seconds").GetInt32();

                return new TimeSpan(hours, minutes, seconds);
            }
        }
        else
        {
            Console.WriteLine("ccccc");
            // Handle other cases, e.g., direct string to TimeSpan conversion
            return TimeSpan.Parse(reader.GetString()!);
        }
    }

    public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
    {
        // Implement serialization logic if necessary
        writer.WriteStringValue(value.ToString());
    }
}