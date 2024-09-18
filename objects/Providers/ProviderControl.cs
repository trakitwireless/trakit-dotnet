using System.Collections.Generic;

namespace trakit.objects {
	/// <summary>
	/// Managing communication with Device/hardware.
	/// </summary>
	public class ProviderControl : Subscribable, IBelongCompany {
		/// <summary>
		/// Unique identifier of this device.
		/// </summary>
		/// <seealso cref="Provider.id" />
		/// <override min-length="10" max-length="50" />
		public string id { get; set; }
		/// <summary>
		/// The company to which this device belongs.
		/// </summary>
		/// <seealso cref="Company.id" />
		public ulong company { get; set; }
		/// <summary>
		/// Collection of commands for this provider.
		/// </summary>
		public Dictionary<ProviderCommandType, ProviderCommand> commands;
	}
}