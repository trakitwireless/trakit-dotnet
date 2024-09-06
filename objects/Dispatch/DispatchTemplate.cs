using System.Collections.Generic;

namespace trakit.objects {
	/// <summary>
	/// A pre-built set of jobs and steps to quickly dispatch for an <see cref="Asset"/>.
	/// </summary>
	/// <category>Dispatch</category>
	public class DispatchTemplate : Subscribable, IIdUlong, INamed, ILabelled, IDeletable, IBelongCompany {
		/// <summary>
		/// Unique identifier of this template.
		/// </summary>
		public ulong id { get; set; }
		/// <summary>
		/// The company to which this template belongs.
		/// </summary>
		/// <seealso cref="Company.id" />
		public ulong company { get; set; }
		/// <summary>
		/// The <see cref="Asset"/> to which the created <see cref="DispatchJob"/>s would be assigned.
		/// </summary>
		/// <seealso cref="Asset.id" />
		public ulong? asset;
		/// <summary>
		/// The name of this template.
		/// </summary>
		/// <override max-length="100" />
		public string name { get; set; }
		/// <summary>
		/// Notes about this template.
		/// </summary>
		public string notes { get; set; }
		public bool deleted { get; set; }
		/// <summary>
		/// Name/value collections of custom fields used to refer to external systems.
		/// </summary>
		/// <override max-count="10">
		/// <keys max-length="20" />
		/// <values max-length="100" />
		/// </override>
		public Dictionary<string, string> references;
		/// <summary>
		/// Codified label names used to target applicable <see cref="Asset"/>s for this dispatch.
		/// </summary>
		/// <override>
		/// <values format="codified">
		/// <seealso cref="LabelStyle.code" />
		/// </values>
		/// </override>
		public List<string> labels { get; set; }
		/// <summary>
		/// The list of jobs to create when deploying this template.
		/// </summary>
		public List<DispatchTemplateJob> jobs;
		/// <summary>
		/// Driving directions and route path details.
		/// </summary>
		public List<DispatchDirection> directions;
	}
}