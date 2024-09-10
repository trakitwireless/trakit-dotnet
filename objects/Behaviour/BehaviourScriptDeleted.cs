using System;

namespace trakit.objects {
	/// <summary>
	/// Business logic run by the system to react to GPS events and device information.
	/// </summary>
	public class BehaviourScriptDeleted : Subscribable, IIdUlong, IDeletable, IBelongCompany {
		/// <summary>
		/// Unique identifier of this script.
		/// </summary>
		public ulong id { get; set; }
		/// <summary>
		/// The company to which this script belongs.
		/// </summary>
		/// <seealso cref="Company.id" />
		public ulong company { get; set; }
		/// <summary>
		/// This flag is always true.
		/// </summary>
		public bool deleted => true;
		/// <summary>
		/// Timestamp from the action that deleted this log.
		/// </summary>
		public DateTime since { get; set; }
	}
}