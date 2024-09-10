using System;

namespace trakit.objects {
	/// <summary>
	/// A task assigned to an asset which represents a coordinate on the map which must be visited.
	/// </summary>
	[Obsolete("Use DispatchJob instead")]
	public class DispatchTaskDeleted : Subscribable, IIdUlong, IDeletable, IBelongCompany, IBelongAsset {
		/// <summary>
		/// Unique identifier of this task.
		/// </summary>
		public ulong id { get; set; }
		/// <summary>
		/// The company to which this task belongs.
		/// </summary>
		/// <seealso cref="Company.id" />
		public ulong company { get; set; }
		/// <summary>
		/// The asset to which this task belongs.
		/// </summary>
		/// <seealso cref="Asset.id" />
		public ulong asset { get; set; }
		/// <summary>
		/// The name of this task or the work needed to be performed.
		/// </summary>
		/// <override max-length="100" />
		public string name;
		/// <summary>
		/// Instructions (filled out by dispatcher) for the field-employee to help them completed the task.
		/// </summary>
		public string instructions;
		/// <summary>
		/// This flag is always true.
		/// </summary>
		public bool deleted => true;
		/// <summary>
		/// Timestamp from the action that deleted this task.
		/// </summary>
		public DateTime since { get; set; }
	}
}