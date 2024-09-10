using System;

namespace trakit.objects {
	/// <summary>
	/// This class describes a type of logic applied to a provider.
	/// A script will generate a file which is loaded onto a provider in the field.
	/// </summary>
	public class ProviderScriptDeleted : Subscribable, IIdUlong, IDeletable, IBelongCompany {
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