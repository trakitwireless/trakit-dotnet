using System;

namespace trakit.objects {
	/// <summary>
	/// The applied behaviour which includes all parameters and targets specific assets.
	/// </summary>
	public class BehaviourDeleted : Subscribable, IIdUlong, IDeletable, IBelongCompany {
		/// <summary>
		/// Unique identifier of this behaviour.
		/// </summary>
		public ulong id { get; set; }
		/// <summary>
		/// The company to which this behaviour belongs.
		/// </summary>
		/// <seealso cref="Company.id" />
		public ulong company { get; set; }
		/// <summary>
		/// This flag is always true.
		/// </summary>
		public bool deleted => true;
		/// <summary>
		/// Timestamp from the action that deleted this behaviour.
		/// </summary>
		public DateTime since { get; set; }
	}
}