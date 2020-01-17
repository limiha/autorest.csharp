// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace body_complex.Models
{
    public partial class LongWrapper : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Field1 != null)
            {
                writer.WritePropertyName("field1");
                writer.WriteNumberValue(Field1.Value);
            }
            if (Field2 != null)
            {
                writer.WritePropertyName("field2");
                writer.WriteNumberValue(Field2.Value);
            }
            writer.WriteEndObject();
        }
        internal static LongWrapper DeserializeLongWrapper(JsonElement element)
        {
            LongWrapper result = new LongWrapper();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("field1"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Field1 = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("field2"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Field2 = property.Value.GetInt64();
                    continue;
                }
            }
            return result;
        }
    }
}
