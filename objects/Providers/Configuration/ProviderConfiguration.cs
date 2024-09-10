﻿using System;
using System.Collections.Generic;

namespace trakit.objects {
	/// <summary>
	/// The configured logic loaded onto the provider over-the-air to control it's reporting schedule and behaviour.
	/// </summary>
	/// <category>Providers and Configurations</category>
	[Obsolete("Use ProviderConfig instead")]
	public class ProviderConfiguration : Subscribable, IIdUlong, INamed, IBelongCompany {
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
		/// The nickname given to this configuration
		/// </summary>
		/// <override max-length="100" />
		public string name { get; set; }
		/// <summary>
		/// Simple details about how the providers are expected to behave.
		/// </summary>
		public string notes { get; set; }
		/// <summary>
		/// The logic type which this configuration implements.
		/// </summary>
		/// <seealso cref="ProviderConfigurationType.id" />
		public ulong type { get; set; }
		/// <summary>
		/// The list of defined variables given to the <see cref="ProviderConfigurationType.scriptOptions">logic type's options</see> pairs for the logic type requires.
		/// </summary>
		public Dictionary<string, object> scriptParameters;
		/// <summary>
		/// List of Places loaded directly onto the provider.
		/// </summary>
		public List<ulong> geofences;
	}
}