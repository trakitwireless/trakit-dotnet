using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace trakit.tools {
	/// <summary>
	/// JSON serialization helper that abides by the rules and settings of the Trak-iT APIs.
	/// </summary>
	public class Serializer {
		/// <summary>
		/// The full ISO8601 date/time string with seconds and milliseconds.
		/// All date/time stamps in the Trak-iT APIs are given in UTC unless otherwise specified.
		/// </summary>
		public const string DATETIME_FORMAT_ISO8601 = "yyyy-MM-ddTHH:mm:ss.fffZ";

		// settings used by Trak-iT's APIs
		internal JsonSerializerSettings _settings;
		// used to convert JObjects into Trak-iT classes
		internal JsonSerializer newton;

		public Serializer() {
			_settings = new JsonSerializerSettings() {
				Formatting = Formatting.None,
				DateParseHandling = DateParseHandling.None,
				DateTimeZoneHandling = DateTimeZoneHandling.Utc,
			};

			// Converts a DateTime to and from the ISO 8601 date format (with seconds and milliseconds)
			_settings.Converters.Add(new IsoDateTimeConverter() {
				DateTimeFormat = DATETIME_FORMAT_ISO8601,
			});
			_settings.Converters.Add(new StringEnumConverter());
			_settings.Converters.Add(new ConvertIDeletable(this));
			_settings.Converters.Add(new ConvertISuspendable(this));
			_settings.Converters.Add(new ConvertAsset(this));
			//_settings.Converters.Add(new ConvertCompany(this));
			//_settings.Converters.Add(new ConvertProvider(this));
			//_settings.Converters.Add(new ConvertPlace(this));
			//_settings.Converters.Add(new ConvertUser(this));

			this.newton = JsonSerializer.CreateDefault(_settings);
		}

		/// <summary>
		/// Serializes the given value that abides the rules of Trak-iT's APIs.
		/// </summary>
		/// <typeparam name="T">Any object or struct.</typeparam>
		/// <param name="value">The value to serialize.</param>
		/// <returns>The serialized value.</returns>
		public string serialize<T>(T value) => JsonConvert.SerializeObject(value, _settings);
		/// <summary>
		/// Attempts to serialize the given value that abides the rules of Trak-iT's APIs.
		/// </summary>
		/// <param name="value">The value to serialize.</param>
		/// <param name="text">The serialized value.</param>
		/// <returns>True when successful.</returns>
		public bool trySerialize<T>(T value, out string text) {
			bool success;
			try {
				text = this.serialize<T>(value);
				success = true;
			} catch {
				text = default;
				success = false;
			}
			return success;
		}

		/// <summary>
		/// Deserializes the given text into an object abiding by the rules of Trak-iT's APIs.
		/// </summary>
		/// <typeparam name="T">Any object or struct.</typeparam>
		/// <param name="text">The serialized value.</param>
		/// <returns>The <typeparamref name="T">object or struct</typeparamref>.</returns>
		public T deserialize<T>(string text) => JsonConvert.DeserializeObject<T>(text, _settings);
		/// <summary>
		/// Attempts to deserializes the given text into an object abiding by the rules of Trak-iT's APIs.
		/// </summary>
		/// <typeparam name="T">Any object or struct.</typeparam>
		/// <param name="text">The serialized value.</param>
		/// <param name="value">The <typeparamref name="T">object or struct</typeparamref>.</param>
		/// <returns>True when successful.</returns>
		public bool tryDeserialize<T>(string text, out T value) {
			bool success;
			try {
				value = this.deserialize<T>(text);
				success = true;
			} catch {
				value = default;
				success = false;
			}
			return success;
		}

		/// <summary>
		/// Converts the given <see cref="JToken"/> into an object abiding by the rules of Trak-iT's APIs.
		/// </summary>
		/// <typeparam name="T">Any type of object, not compatible with structs.</typeparam>
		/// <param name="token">JSON of the desired <typeparamref name="T">value</typeparamref>.</param>
		/// <returns>The desired <typeparamref name="T">value</typeparamref>.</returns>
		public T convert<T>(JToken token) => token.ToObject<T>(this.newton);
		/// <summary>
		/// Attempts to converts the given <see cref="JToken"/> into an object abiding by the rules of Trak-iT's APIs.
		/// </summary>
		/// <typeparam name="T">Any type of object, not compatible with structs.</typeparam>
		/// <param name="token">JSON of the desired <typeparamref name="T">value</typeparamref>.</param>
		/// <param name="value">The desired <typeparamref name="T">value</typeparamref>.</param>
		/// <returns>True when successful.</returns>
		public bool tryConvert<T>(JToken token, out T value) {
			bool success;
			try {
				value = this.convert<T>(token);
				success = true;
			} catch {
				value = default;
				success = false;
			}
			return success;
		}
		/// <summary>
		/// Converts the given <typeparamref name="T">value</typeparamref> into <see cref="JToken"/> abiding by the rules of Trak-iT's APIs.
		/// </summary>
		/// <typeparam name="T">Any object or struct.</typeparam>
		/// <typeparam name="J">The kind of JSON token being returned.</typeparam>
		/// <param name="value">The <typeparamref name="T">object or struct</typeparamref>.</param>
		/// <returns>The desired <see cref="JToken"/>.</returns>
		public J convert<T, J>(T value) where J : JToken => (J)JToken.FromObject(value, this.newton);
		/// <summary>
		/// Attempts to converts the given <typeparamref name="T">value</typeparamref> into <see cref="JToken"/> abiding by the rules of Trak-iT's APIs.
		/// </summary>
		/// <typeparam name="T">Any object or struct.</typeparam>
		/// <typeparam name="J">The kind of JSON token being returned.</typeparam>
		/// <param name="value">The <typeparamref name="T">object or struct</typeparamref>.</param>
		/// <param name="token">The desired <see cref="JToken"/>.</param>
		/// <returns>True when successful.</returns>
		public bool tryConvert<T, J>(T value, out J token) where J : JToken {
			bool success;
			try {
				token = this.convert<T, J>(value);
				success = true;
			} catch {
				token = default;
				success = false;
			}
			return success;
		}
	}
}