// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace body_complex.Models
{
    public partial class Cookiecuttershark : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Age != null)
            {
                writer.WritePropertyName("age");
                writer.WriteNumberValue(Age.Value);
            }
            writer.WritePropertyName("birthday");
            writer.WriteStringValue(Birthday, "S");
            writer.WritePropertyName("fishtype");
            writer.WriteStringValue(Fishtype);
            if (Species != null)
            {
                writer.WritePropertyName("species");
                writer.WriteStringValue(Species);
            }
            writer.WritePropertyName("length");
            writer.WriteNumberValue(Length);
            if (Siblings != null)
            {
                writer.WritePropertyName("siblings");
                writer.WriteStartArray();
                foreach (var item in Siblings)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }
        internal static Cookiecuttershark DeserializeCookiecuttershark(JsonElement element)
        {
            Cookiecuttershark result = new Cookiecuttershark();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("age"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Age = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("birthday"))
                {
                    result.Birthday = property.Value.GetDateTimeOffset("S");
                    continue;
                }
                if (property.NameEquals("fishtype"))
                {
                    result.Fishtype = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("species"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Species = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("length"))
                {
                    result.Length = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("siblings"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Siblings = new List<Fish>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.Siblings.Add(DeserializeFish(item));
                    }
                    continue;
                }
            }
            return result;
        }
    }
}
