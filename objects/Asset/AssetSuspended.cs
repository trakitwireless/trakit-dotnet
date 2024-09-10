using System;
using System.Collections.Generic;

namespace trakit.objects {
	/// <summary>
	/// Seldom changing details about a thing.
	/// </summary>
	public class AssetSuspended : Subscribable, IIdUlong, ISuspendable, IBelongCompany {
		/// <summary>
		/// Unique identifier of this asset.
		/// </summary>
		/// <seealso cref="Asset.id" />
		public ulong id { get; set; }
		/// <summary>
		/// The company to which this asset belongs.
		/// </summary>
		/// <seealso cref="Company.id" />
		public ulong company { get; set; }
		/// <summary>
		/// Type of asset.
		/// </summary>
		public AssetType kind { get; set; }
		/// <summary>
		/// This thing's name.
		/// </summary>
		/// <override max-length="100" />
		public string name { get; set; }
		/// <summary>
		/// The icon that represents this asset on the map and in lists.
		/// </summary>
		/// <seealso cref="Icon.id" />
		public ulong icon { get; set; }
		/// <summary>
		/// Notes about it.
		/// </summary>
		public string notes { get; set; }
		/// <summary>
		/// Indicates whether this Asset is suspended from event processing.
		/// </summary>
		public bool suspended => true;
		/// <summary>
		/// Timestamp that indicates when the asset was suspended or revived.
		/// </summary>
		public DateTime since { get; set; }
		/// <summary>
		/// Codified label names.
		/// </summary>
		/// <override>
		/// <values format="codified">
		/// <seealso cref="LabelStyle.code" />
		/// </values>
		/// </override>
		public List<string> labels { get; set; }
	}
}