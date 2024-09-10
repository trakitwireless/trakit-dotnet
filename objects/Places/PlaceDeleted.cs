using System;

namespace trakit.objects {
	/// <summary>
	/// A POI (point-of-interest) saved to the system to help determine an asset's real-world position.
	/// </summary>
	public class PlaceDeleted : Subscribable, IIdUlong, IDeletable, IBelongCompany {
		/// <summary>
		/// Unique identifier of this POI.
		/// </summary>
		public ulong id { get; set; }
		/// <summary>
		/// The company to which this POI belongs.
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