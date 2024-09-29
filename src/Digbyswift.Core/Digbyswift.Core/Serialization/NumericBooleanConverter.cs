using System;
using Digbyswift.Core.Constants;
using Newtonsoft.Json;

namespace Digbyswift.Core.Serialization;

public class NumericBooleanConverter : JsonConverter
{
#if NET48
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
#else
    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
#endif
    {
        if (value is bool boolValue)
        {
            writer.WriteValue(boolValue ? NumericConstants.One : NumericConstants.Zero);
        }
        else if (serializer.NullValueHandling == NullValueHandling.Include)
        {
            writer.WriteNull();
        }
    }

#if NET48
    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
#else
    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
#endif
    {
        return reader.Value?.Equals(StringConstants.One);
    }

    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(bool);
    }
}
