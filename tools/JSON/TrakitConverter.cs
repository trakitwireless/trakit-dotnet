using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using trakit.objects;

namespace trakit.tools {
	/// <summary>
	/// 
	/// </summary>
	public abstract class TrakitConverter<T> : JsonConverter<T> where T : Subscribable {

		protected JsonObject readObject(ref Utf8JsonReader reader) {
			if (reader.TokenType != JsonTokenType.StartObject) throw new JsonException();
			var obj = new JsonObject();
			while (reader.Read()) {
				if (reader.TokenType == JsonTokenType.EndObject) break;
				if (reader.TokenType != JsonTokenType.PropertyName) throw new JsonException();

				string key = reader.GetString();
				reader.Read();
				obj.Add(key, JsonNode.Parse(ref reader));
			}
			return obj;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="writer"></param>
		/// <param name="value"></param>
		/// <param name="options"></param>
		public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
			=> JsonSerializer.Serialize(writer, value, typeof(T), options);
	}
}