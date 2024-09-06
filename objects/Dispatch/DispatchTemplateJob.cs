using System.Collections.Generic;

namespace trakit.objects {
	/// <summary>
	/// A reusable template of work that needs to be done by performing one or more <see cref="DispatchStep"/>s.
	/// </summary>
	/// <category>Dispatch</category>
	public class DispatchTemplateJob {
		/// <summary>
		/// The name of this template or the work needed to be performed.
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
		/// Instructions (filled out by dispatcher) for the field-employee to help them completed the job.
		/// </summary>
		public string instructions;
		/// <summary>
		/// A list of hosted <see cref="Document"/> identifiers attached to this template.
		/// </summary>
		/// <override max-count="10">
		/// <values>
		/// <seealso cref="Document.id" />
		/// </values>
		/// </override>
		public List<ulong> attachments;
		/// <summary>
		/// A list of hosted <see cref="FormResult"/> identifiers attached to this template.
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
		/// A list of coordinates to visit in order to carry out the work for the created <see cref="DispatchJob"/>.
		/// </summary>
		public List<DispatchStep> steps;
	}
}