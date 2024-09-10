using System;

namespace trakit.objects {
	/// <summary>
	/// A debug message available to script writers to help debug and trace output from a BehaviourScript.
	/// </summary>
	public class BehaviourLogDeleted : Subscribable, IIdUlong, IDeletable, IBelongCompany, IBelongAsset {
		/// <summary>
		/// Unique identifier of this log message.
		/// </summary>
		public ulong id { get; set; }
		/// <summary>
		/// The asset which whose behaviours created this log entry.
		/// </summary>
		/// <seealso cref="Asset.id" />
		public ulong asset { get; set; }
		/// <summary>
		/// The company to which this log message belongs.
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