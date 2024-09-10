using System;

namespace trakit.objects {
	/// <summary>
	/// Device/hardware information and configuration.
	/// </summary>
	public class ProviderSuspended : Subscribable, INamed, IBelongCompany, ISuspendable {
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
		/// The kind of communication protocol this device uses.
		/// </summary>
		public ProviderType kind;
		/// <summary>
		/// A nickname given to the device/hardware.
		/// </summary>
		/// <override max-length="100" />
		public string name { get; set; }
		/// <summary>
		/// Notes!
		/// </summary>
		public string notes { get; set; }
		/// <summary>
		/// The provider's current (or pending) configuration profile.
		/// </summary>
		/// <seealso cref="ProviderConfig.id" />
		/// <seealso cref="ProviderConfiguration.id" />
		public ulong configuration;
		/// <summary>
		/// This flag is always true.
		/// </summary>
		public bool suspended => true;
		/// <summary>
		/// Timestamp from the action that deleted this device.
		/// </summary>
		public DateTime since { get; set; }
	}
}