using System;
using System.Collections.Generic;

namespace trakit.objects {
	/// <summary>
	/// Some work that needs to be done by performing one or more <see cref="DispatchStep"/>s.
	/// </summary>
	public class DispatchJobDeleted : Subscribable, IIdUlong, IDeletable, ILabelled, IBelongCompany {
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
		/// A name for the work needed to be performed.
		/// </summary>
		/// <override max-length="100" />
		public string name;
		/// <summary>
		/// Instructions (filled out by dispatcher) for the field-employee to help them complete the job.
		/// </summary>
		public string instructions;
		/// <summary>
		/// Codified label names used to relate (unassigned) jobs to <see cref="Asset"/>s.
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
		/// Timestamp from the action that deleted this task.
		/// </summary>
		public DateTime since { get; set; }
	}
}