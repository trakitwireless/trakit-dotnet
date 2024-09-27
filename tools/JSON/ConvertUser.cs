using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using trakit.objects;

namespace trakit.tools {
	/// <summary>
	/// 
	/// </summary>
	public class ConvertUser : JsonConverter<User> {

		public override User? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {

		}
		public override void Write(Utf8JsonWriter writer, User value, JsonSerializerOptions options) {

		}
	}
}