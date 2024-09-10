using System.Collections.Generic;

namespace trakit.objects {
	/// <summary>
	/// The configured script loaded onto the provider over-the-air to control it's reporting schedule and behaviour.
	/// </summary>
	/// <category>Providers and Configurations</category>
	public class ProviderConfig : Subscribable, IIdUlong, INamed,  IBelongCompany {
		/// <summary>
		/// Unique identifier of this configuration.
		/// </summary>
		public ulong id { get; set; }
		/// <summary>
		/// The company to which this configuration belongs.
		/// </summary>
		/// <seealso cref="Company.id" />
		public ulong company { get; set; }
		/// <summary>
		/// The script which this configuration implements.
		/// </summary>
		/// <seealso cref="ProviderScript.id" />
		public ulong script { get; set; }
		/// <summary>
		/// The nickname given to this configuration
		/// </summary>
		/// <override max-length="100" />
		public string name { get; set; }
		/// <summary>
		/// Simple details about how the providers are expected to behave.
		/// </summary>
		public string notes { get; set; }
		/// <summary>
		/// The list of defined variable name/value pairs that the script requires.
		/// </summary>
		public Dictionary<string, string> parameters;
		/// <summary>
		/// A search pattern used to filter which Places' geometry are used as geofences.
		/// Use null to disable.
		/// Use "*" to match all the Places the Provider's Asset can match.
		/// Or use "#123456" or "label:term" like other Place search patterns.
		/// </summary>
		/// <override type="System.String" format="expression" />
		public string geofences;
	}
}