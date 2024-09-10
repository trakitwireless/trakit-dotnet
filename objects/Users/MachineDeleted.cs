using System;

namespace trakit.objects {
	/// <summary>
	/// A service account that allowes for API access of system services.
	/// </summary>
	public class MachineDeleted : Subscribable, IDeletable, IBelongCompany {
		/// <summary>
		/// The unique idenifier used to access the system.
		/// </summary>
		/// <override max-length="50" />
		public string key { get; set; }
		/// <summary>
		/// The company to which this user belongs.
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