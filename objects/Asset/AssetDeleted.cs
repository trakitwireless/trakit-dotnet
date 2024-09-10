using System;

namespace trakit.objects {
	/// <summary>
	/// The full details of an Asset, containing all the properties from the <see cref="AssetGeneral"/> and <see cref="AssetAdvanced"/> objects.
	/// </summary>
	public class AssetDeleted : Subscribable, IIdUlong, IDeletable, IBelongCompany {
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
		/// This flag is always true.
		/// </summary>
		public bool deleted => true;
		/// <summary>
		/// Timestamp from the action that deleted this asset.
		/// </summary>
		public DateTime since { get; set; }
	}
}