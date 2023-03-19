using System.Text.Json;
using System.Text.Json.Serialization;
using PizzaStore.Core.Abstractions;

namespace PizzaStore.API.JsonConverters
{
    public class CommandConverter : JsonConverter<Command>
    {
        private static Dictionary<string, Type> TypeLookup;

        static CommandConverter()
        {
            TypeLookup = new Dictionary<string, Type>();

            var commandTypes = typeof(Command)
                .Assembly
                .GetTypes()
                .Where(type => !type.IsAbstract && typeof(Command).IsAssignableFrom(type));

            foreach (var commandType in commandTypes)
            {
                TypeLookup[commandType.Name] = commandType;
            }
        }

        public override bool CanConvert(Type type)
        {
            return typeof(Command).IsAssignableFrom(type);
        }

        public override Command Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            if (!reader.Read()
                    || reader.TokenType != JsonTokenType.PropertyName
                    || reader.GetString().ToLower() != "$type")
            {
                throw new JsonException();
            }

            if (!reader.Read() || reader.TokenType != JsonTokenType.String)
            {
                throw new JsonException();
            }

            Command command;
            string typeDiscriminator = reader.GetString();
            var commandType = TypeLookup[typeDiscriminator];


            if (!reader.Read() || reader.GetString().ToLower() != "command")
            {
                throw new JsonException();
            }
            if (!reader.Read() || reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            command = (Command)JsonSerializer.Deserialize(ref reader, commandType);

            if (!reader.Read() || reader.TokenType != JsonTokenType.EndObject)
            {
                throw new JsonException();
            }

            return command;
        }

        public override void Write(Utf8JsonWriter writer, Command value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            writer.WriteString("$type", value.GetType().Name);
            writer.WritePropertyName("command");
            JsonSerializer.Serialize(writer, value, value.GetType());

            writer.WriteEndObject();
        }
    }
}
