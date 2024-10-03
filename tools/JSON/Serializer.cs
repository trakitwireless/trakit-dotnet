using System;
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
			this.settings.Converters.Add(new ConvertAsset());
			this.settings.Converters.Add(new ConvertCompany());
			this.settings.Converters.Add(new ConvertPlace());
			this.settings.Converters.Add(new ConvertPlace());
			this.settings.Converters.Add(new ConvertUser());
		}

		public string serialize<T>(T body) => throw new NotImplementedException();
		public T deserialize<T>(string body) => throw new NotImplementedException();
	}
}