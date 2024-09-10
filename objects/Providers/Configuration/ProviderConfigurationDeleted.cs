using System;

namespace trakit.objects {
	/// <summary>
	/// The configured logic loaded onto the provider over-the-air to control it's reporting schedule and behaviour.
	/// </summary>
	[Obsolete("Use ProviderConfig instead")]
	public class ProviderConfigurationDeleted : Subscribable, IIdUlong, IDeletable, IBelongCompany {
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
		/// This flag is always true.
		/// </summary>
		public bool deleted => true;
		/// <summary>
		/// Timestamp from the action that deleted this asset.
		/// </summary>
		public DateTime since { get; set; }
	}
}