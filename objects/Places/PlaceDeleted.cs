using System;
using System.Collections.Generic;

namespace trakit.objects {
	/// <summary>
	/// A POI (point-of-interest) saved to the system to help determine an asset's real-world position.
	/// </summary>
	public class PlaceDeleted : Subscribable, IIdUlong, IDeletable, INamed, IIconic, IBelongCompany, ILabelled {
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
		/// The kind of geography represented by this POI.
		/// </summary>
		public PlaceType kind;
		/// <summary>
		/// POI's common name instead of street address.
		/// </summary>
		/// <override max-length="100" />
		public string name { get; set; }
		/// <summary>
		/// The icon used to display this POI in lists and on the map.
		/// </summary>
		/// <seealso cref="Icon.id" />
		public ulong icon { get; set; }
		/// <summary>
		/// Notes!
		/// </summary>
		public string notes { get; set; }
		/// <summary>
		/// The codified names of labels
		/// </summary>
		/// <override>
		/// <values format="codified">
		/// <seealso cref="LabelStyle.code" />
		/// </values>
		/// </override>
		public List<string> labels { get; set; }
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