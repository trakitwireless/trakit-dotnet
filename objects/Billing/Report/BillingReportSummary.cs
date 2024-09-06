using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace trakit.objects {
	/// <summary>
	/// Summarized bill per target.
	/// </summary>
	/// <category>Billing</category>
	public class BillingReportSummary : INamed {
		/// <summary>
		/// The target company to which this summary instance belongs.
		/// </summary>
		/// <seealso cref="Company.id" />
		public ulong target{ get; set; }
		/// <summary>
		/// The target company's parent.
		/// </summary>
		/// <seealso cref="Company.id" />
		public ulong parent{ get; set; }
		/// <summary>
		/// Target's name.
		/// </summary>
		/// <override max-length="100" />
		public string name { get; set; }
		/// <summary>
		/// Notes about the target.
		/// </summary>
		public string notes { get; set; }
		/// <summary>
		/// Summary contains totals per type of hosting (services and licenses) for this target
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public List<BillingReportHostingSummary> hosting;

		public BillingReportSummary(
			ulong target,
			ulong parent,
			string name,
			string notes,
			IEnumerable<BillingReportHostingSummary> hosting = null
		) {
			this.target = target;
			this.parent = parent;
			this.name = name;
			this.notes = notes;
			this.hosting = hosting?.ToList() ?? new List<BillingReportHostingSummary>();
		}
		public BillingReportSummary(XElement node) {
			this.target = ulong.Parse(node.Attribute("target").Value);
			this.parent = ulong.Parse(node.Attribute("parent").Value);
			this.name = node.Attribute("name").Value;
			this.notes = node.Attribute("notes").Value;
			this.hosting = node.Element("hostingSummary")
									?.Elements()
									.Select(el => new BillingReportHostingSummary(el))
									.ToList();
		}

		public XElement toXml() {
			return new XElement("summary",
				new XAttribute("target", this.target),
				new XAttribute("parent", this.parent),
				new XAttribute("name", this.name),
				new XAttribute("notes", this.notes),
				new XElement("hostingSummary", this.hosting?.Select(s => s.toXml()))
			);
		}
	}
}