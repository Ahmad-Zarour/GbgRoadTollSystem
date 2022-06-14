namespace RoadTollSystem
{
    //System.Text.Json doesn’t provide built-in support for DateOnly.
    //Converters to handle DateOnly, inheriting the JsonConverter class to help to serializeation
    public class DateOnlyConverter : JsonConverter<DateOnly>
    {
        private readonly string _serializationFormat;

        public DateOnlyConverter() : this(null)
        {
        }

        public DateOnlyConverter(string? serializationFormat)
        {
            _serializationFormat = serializationFormat ?? "yyyy'-'MM'-'dd";
        }

        public override DateOnly Read(ref Utf8JsonReader reader,
            Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            return DateOnly.Parse(value!);
        }

        public override void Write(Utf8JsonWriter writer, DateOnly value,
            JsonSerializerOptions options)
            => writer.WriteStringValue(value.ToString(_serializationFormat));
    }

}
