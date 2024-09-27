using System;
using Digbyswift.Core.Constants;
using Newtonsoft.Json;

namespace Digbyswift.Core.Serialization;

public class BoolConverter : JsonConverter
{
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        writer.WriteValue(((bool)value) ? NumericConstants.One : NumericConstants.Zero);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        return reader.Value.ToString() == StringConstants.One;
    }

    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(bool);
    }
}