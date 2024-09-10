using System;

namespace trakit.objects {
	/// <summary>
	/// This read-only class describes a type of logic applied to a provider.
	/// ProviderConfigurationTypes are used to help define a ProviderConfiguration.
	/// </summary>
	/// <category>Providers and Configurations</category>
	[Obsolete("Use ProviderScript instead")]
	public class ProviderConfigurationTypeDeleted : Subscribable, IIdUlong, IDeletable {
		/// <summary>
		/// Unique identifier.
		/// </summary>
		public ulong id { get; set; }
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