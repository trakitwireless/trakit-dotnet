using System;

namespace trakit.objects {
	/// <summary>
	/// A visual representation of a thing on a map or in a list.
	/// </summary>
	public class IconDeleted : Subscribable, IIdUlong, IDeletable, INamed, IBelongCompany {
		/// <summary>
		/// Unique identifier of this icon.
		/// </summary>
		public ulong id { get; set; }
		/// <summary>
		/// The company to which this icon belongs.
		/// </summary>
		/// <seealso cref="Company.id" />
		public ulong company { get; set; }
		/// <summary>
		/// A specific adjective to describe the thing.  Like Blue, Red, Empty, Full, etc...
		/// </summary>
		/// <override max-length="100" />
		public string name { get; set; }
		/// <summary>
		/// Notes.
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