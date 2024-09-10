using System.Runtime.Serialization;

namespace trakit.objects {
	/// <summary>
	/// A partially created report used to quickly build results.
	/// </summary>
	/// <category>Reports</category>
	public class ReportTemplate : Subscribable, IIdUlong, INamed, IBelongCompany, IVisual {
		/// <summary>
		/// Unique identifier
		/// </summary>
		public ulong id { get; set; }
		/// <summary>
		/// The company to which this report belongs
		/// </summary>
		/// <seealso cref="Company.id" />
		public ulong company { get; set; }
		/// <summary>
		/// Refers to the type of logic used by this report.
		/// </summary>
		public ReportType type { get; set; }
		/// <summary>
		/// Name of this report.
		/// </summary>
		/// <override max-length="100" />
		public string name { get; set; }
		/// <summary>
		/// Notes about this report.
		/// </summary>
		public string notes { get; set; }
		/// <summary>
		/// Specified parameters for the report logic, targeted Assets, and filtering Places.
		/// </summary>
		public ReportOptions options;

		/// <summary>
		/// The fill/background colour of the icon.
		/// </summary>
		/// <override max-length="22" format="colour" />
		[DataMember]
		public string fill { get; set; }
		/// <summary>
		/// Outline and graphic colour.
		/// </summary>
		/// <override max-length="22" format="colour" />
		[DataMember]
		public string stroke { get; set; }
		/// <summary>
		/// The name of the symbol for this report.
		/// </summary>
		/// <override max-length="22" format="codified" />
		[DataMember]
		public string graphic { get; set; }
	}
}