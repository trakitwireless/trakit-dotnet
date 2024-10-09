using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace trakit.tools {
	/// <summary>
	/// 
	/// </summary>
	public class Serializer {
		/// <summary>
		/// 
		/// </summary>
		public const string DATETIME_FORMAT_ISO8601 = "yyyy-MM-ddTHH:mm:ss.fffZ";
		/// <summary>
		/// 
		/// </summary>
		JsonSerializerSettings settings = new JsonSerializerSettings();

		public Serializer() {
			this.settings.DateParseHandling = DateParseHandling.None;
			this.settings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
			this.settings.MaxDepth = 128; // https://github.com/advisories/GHSA-5crp-9r3c-p9vr

			// Converts a DateTime to and from the ISO 8601 date format 
			this.settings.Converters.Add(new IsoDateTimeConverter() {
				DateTimeFormat = DATETIME_FORMAT_ISO8601,
			});


			this.settings.Converters.Add(new StringEnumConverter());
			//this.settings.Converters.Add(new ConvertAsset());
			//this.settings.Converters.Add(new ConvertCompany());
			//this.settings.Converters.Add(new ConvertPlace());
			//this.settings.Converters.Add(new ConvertPlace());
			//this.settings.Converters.Add(new ConvertUser());
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="value"></param>
		/// <returns></returns>
		public string serialize<T>(T value) => JsonConvert.SerializeObject(value, this.settings);

		/// <summary>
		/// Attempts to deserialize the given string and outs the value.
		/// If an exception is thrown, false is returned, and null is outputted.
		/// </summary>
		/// <param name="text"></param>
		/// <param name="value"></param>
		/// <returns></returns>
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
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="value"></param>
		/// <returns></returns>
		public T deserialize<T>(string value) => JsonConvert.DeserializeObject<T>(value, this.settings);
		/// <summary>
		/// Attempts to deserialize the given string and outs the value.
		/// If an exception is thrown, false is returned, and null is outputted.
		/// </summary>
		/// <param name="text"></param>
		/// <param name="value"></param>
		/// <returns></returns>
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
	}
}