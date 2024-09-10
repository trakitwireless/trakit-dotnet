using System;

namespace trakit.objects {
	/// <summary>
	/// A file stored temporarily by the system.
	/// </summary>
	public class DocumentDeleted : Subscribable, IIdUlong, IDeletable, INamed, IBelongCompany {
		/// <summary>
		/// Unique identifier of this file.
		/// </summary>
		public ulong id { get; set; }
		/// <summary>
		/// The company to which this file belongs.
		/// </summary>
		/// <seealso cref="Company.id" />
		public ulong company { get; set; }
		/// <summary>
		/// The file name of this file.
		/// </summary>
		/// <override max-length="100" />
		public string name { get; set; }
		/// <summary>
		/// Notes about this file.
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