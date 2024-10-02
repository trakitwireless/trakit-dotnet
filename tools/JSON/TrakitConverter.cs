using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using trakit.objects;

namespace trakit.tools {
	/// <summary>
	/// 
	/// </summary>
	public abstract class TrakitConverter<T> : JsonConverter<T> where T : Subscribable {
		/// <summary>
		/// 
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		/// <exception cref="JsonException"></exception>
		protected JsonNode readJson(ref Utf8JsonReader reader) {
			JsonNode node = null;
			while (reader.Read()) {
				switch (reader.TokenType) {
					case JsonTokenType.None:
					case JsonTokenType.Null:
						break;
					case JsonTokenType.StartObject:
						var obj = new JsonObject();
						while (reader.Read()) {
							if (reader.TokenType == JsonTokenType.EndObject) break;
							if (reader.TokenType != JsonTokenType.PropertyName) throw new JsonException();

							string key = reader.GetString();
							reader.Read();
							obj.Add(key, this.readJson(ref reader));
						}
						node = obj;
						break;
					case JsonTokenType.StartArray:
						var arr = new JsonArray();
						while (reader.Read()) {
							if (reader.TokenType == JsonTokenType.EndArray) break;
							arr.Add(this.readJson(ref reader));
						}
						node = arr;
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