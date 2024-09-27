using System.Text.Json;
using System.Text.Json.Serialization;

namespace trakit.tools {
	/// <summary>
	/// 
	/// </summary>
	public class Serializer {
		/// <summary>
		/// 
		/// </summary>
		public const string DATETIME_FORMAT_ISO8601 = "yyyy-MM-ddTHH:mm:ss.fffZ";

		JsonSerializerOptions options = new JsonSerializerOptions();

		public Serializer() {
			this.options.AllowTrailingCommas = true;
			this.options.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
			this.options.NumberHandling = JsonNumberHandling.Strict;
			//this.options.WriteIndented = false;

			this.options.Converters.Add(new JsonStringEnumConverter());
			this.options.Converters.Add(new ConvertAsset());
			this.options.Converters.Add(new ConvertCompany());
			this.options.Converters.Add(new ConvertPlace());
			this.options.Converters.Add(new ConvertPlace());
			this.options.Converters.Add(new ConvertUser());
		}


	}
}