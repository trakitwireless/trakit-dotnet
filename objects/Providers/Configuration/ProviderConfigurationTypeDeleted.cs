﻿using System;

namespace trakit.objects {
	/// <summary>
	/// This read-only class describes a type of logic applied to a provider.
	/// ProviderConfigurationTypes are used to help define a ProviderConfiguration.
	/// </summary>
	[Obsolete("Use ProviderScript instead")]
	public class ProviderConfigurationTypeDeleted : Subscribable, IIdUlong, INamed, IDeletable {
		/// <summary>
		/// Unique identifier.
		/// </summary>
		public ulong id { get; set; }
		/// <summary>
		/// Name of the configuration type.
		/// </summary>
		/// <override max-length="100" />
		public string name { get; set; }
		/// <summary>
		/// Notes regarding the use of this configuration.
		/// </summary>
		public string notes { get; set; }
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