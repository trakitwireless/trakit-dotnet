using System;
using System.Collections.Generic;

namespace trakit.objects {
	/// <summary>
	/// A value assigned to <see cref="DispatchJob"/>s in order to weigh them when optimizing a route.
	/// </summary>
	public enum DispatchJobPriority : byte {
		/// <summary>
		/// Will be done last, after all others, if at all.
		/// </summary>
		standby,
		/// <summary>
		/// Low priority jobs are assigned towards the end of a dispatch, unless they are in very close proximity to another job.
		/// </summary>
		low,
		/// <summary>
		/// A normal job that will be done at the first opportunity.
		/// </summary>
		medium,
		/// <summary>
		/// More important job that will be routed to first unless the next high importance job is much farther away.
		/// </summary>
		high,
		/// <summary>
		/// Must be done first, before all others.
		/// </summary>
		urgent,
	}

	/// <summary>
	/// Some work that needs to be done by performing one or more <see cref="DispatchStep"/>s.
	/// </summary>
	public class DispatchJob : Subscribable, IIdUlong, ILabelled, IBelongCompany {
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
		/// The <see cref="Asset"/> to which this job belongs.
		/// This value is null when unassigned.
		/// </summary>
		/// <seealso cref="Asset.id" />
		public ulong? asset;
		/// <summary>
		/// A name for the work needed to be performed.
		/// </summary>
		/// <override max-length="100" />
		public string name;
		/// <summary>
		/// Name/value collections of custom fields used to refer to external systems.
		/// </summary>
		/// <override max-count="10">
		/// <keys max-length="20" />
		/// <values max-length="100" />
		/// </override>
		public Dictionary<string, string> references;
		/// <summary>
		/// Instructions (filled out by dispatcher) for the field-employee to help them complete the job.
		/// </summary>
		public string instructions;
		/// <summary>
		/// A list of hosted <see cref="Document"/> identifiers attached to this job.
		/// </summary>
		/// <override max-count="10">
		/// <values>
		/// <seealso cref="Document.id" />
		/// </values>
		/// </override>
		public List<ulong> attachments;
		/// <summary>
		/// A list of hosted <see cref="FormResult"/> identifiers attached to this job.
		/// </summary>
		/// <override max-count="10">
		/// <values>
		/// <seealso cref="FormResult.id" />
		/// </values>
		/// </override>
		public List<ulong> forms;
		/// <summary>
		/// The importance of this job when scheduling for an asset.
		/// </summary>
		public DispatchJobPriority priority;
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
		/// The codified status tag names reflecting the conditions of this job.
		/// </summary>
		/// <override>
		/// <values format="codified">
		/// <seealso cref="LabelStyle.code" />
		/// </values>
		/// </override>
		public List<string> tags { get; set; }
		/// <summary>
		/// A list of coordinates to visit in order to carry out the work for this job.
		/// </summary>
		public List<DispatchStep> steps { get; set; }
		/// <summary>
		/// When this job was originally created.
		/// </summary>
		public DateTime created;
		/// <summary>
		/// Clocked-in driver name who made the update.
		/// Null if not clocked-in, or no changes have been made.
		/// </summary>
		public string driver;
	}
}