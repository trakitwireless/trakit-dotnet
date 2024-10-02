using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using trakit.objects;

namespace trakit.tools {
	/// <summary>
	/// 
	/// </summary>
	public abstract class TrakitConverter<T> : JsonConverter<T> where T : Subscribable {

		protected JsonNode read(ref Utf8JsonReader reader) {
			JsonNode node = null;
			while (reader.Read()) {
				switch (reader.TokenType) {
					case JsonTokenType.None:
					case JsonTokenType.Null:
						break;
					case JsonTokenType.StartObject:
						node = this.readObject(ref reader);
						break;
					case JsonTokenType.StartArray:
						node = this.readArray(ref reader);
						break;
					case JsonTokenType.String:
						node = reader.GetString();
						break;
					case JsonTokenType.Number:
						if (reader.TryGetInt64(out long l)) node = l;
						if (reader.TryGetDouble(out double d)) node = d;
						break;
					case JsonTokenType.True:
					case JsonTokenType.False:
						node = reader.GetBoolean();
						break;
					default:
						throw new JsonException();
				}
			}
			return node;
		}
		protected JsonArray readArray(ref Utf8JsonReader reader) {
			if (reader.TokenType != JsonTokenType.StartArray) throw new JsonException();
			var obj = new JsonArray();
			while (reader.Read()) {
				if (reader.TokenType == JsonTokenType.EndArray) break;

				string key = reader.GetString();
				reader.Read();
				obj.Add(key, JsonNode.Parse(ref reader));
			}
			return obj;
		}


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