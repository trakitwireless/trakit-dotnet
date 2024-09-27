using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using trakit.objects;

namespace trakit.tools {
	/// <summary>
	/// 
	/// </summary>
	public class ConvertCompany : JsonConverter<Company> {

		public override Company? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {

		}
		public override void Write(Utf8JsonWriter writer, Company value, JsonSerializerOptions options) {

		}
	}
}