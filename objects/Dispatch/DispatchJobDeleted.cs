using System;

namespace trakit.objects {
	/// <summary>
	/// Some work that needs to be done by performing one or more <see cref="DispatchStep"/>s.
	/// </summary>
	public class DispatchJobDeleted : Subscribable, IIdUlong, IDeletable, IBelongCompany {
		/// <summary>
		/// Unique identifier of this job.
		/// </summary>
		public ulong id { get; set; }
		/// <summary>
		/// The company to which this job belongs.
		/// </summary>
		/// <seealso cref="Company.id" />
		public ulong company { get; set; }
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