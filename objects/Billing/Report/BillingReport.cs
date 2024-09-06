using System;
using System.Collections.Generic;

namespace trakit.objects {
	/// <summary>
	/// The lifetime of building a <see cref="BillingReport"/>.
	/// </summary>
	/// <category>Billing</category>
	public enum BillingReportStatus : byte {
		/// <summary>
		/// The <see cref="BillingReport"/> has been requested, but not yet begun processing.
		/// </summary>
		created,
		/// <summary>
		/// The <see cref="BillingReport"/> is waiting for required resources to begin processing.
		/// </summary>
		queued,
		/// <summary>
		/// The <see cref="BillingReport"/> is currently being processed.
		/// </summary>
		running,
		/// <summary>
		/// The <see cref="BillingReport"/> is available for retrieval.
		/// </summary>
		completed,
		/// <summary>
		/// There was an error processing the <see cref="BillingReport"/>; see the <see cref="BillingReport.error"/> for a description.
		/// </summary>
		failed,
	}

	/// <summary>
	/// Report generated per billee company.
	/// </summary>
	/// <category>Billing</category>
	public class BillingReport : Subscribable, IIdUlong, INamed, IDeletable, IBelongCompany, IBelongBillingProfile {
		/// <summary>
		/// Unique identifier
		/// </summary>
		public ulong id { get; set; }
		/// <summary>
		/// The company to which this report belongs and is sending the bill.
		/// </summary>
		/// <seealso cref="Company.id" />
		public ulong company { get; set; }
		/// <summary>
		/// Unique identifier of the Company receiving the bill.
		/// </summary>
		/// <seealso cref="Company.id" />
		public ulong billee { get; set; }
		/// <summary>
		/// The profile to which this report belongs
		/// </summary>
		/// <seealso cref="BillingProfile.id" />
		public ulong profile { get; set; }
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
		/// Indicates whether this report is deleted.
		/// </summary>
		public bool deleted { get; set; }
		/// <summary>
		/// First day of the billing cycle
		/// </summary>
		public DateTime startDate;
		/// <summary>
		/// Last day of the billing cycle
		/// </summary>
		public DateTime endDate;
		/// <summary>
		/// Total amount being billed.
		/// </summary>
		public double total;
		/// <summary>
		/// Currency being billed in
		/// </summary>
		public BillingCurrency currency { get; set; }
		/// <summary>
		/// The processing status of this report.
		/// </summary>
		public BillingReportStatus status;
		/// <summary>
		/// A field which contains report error details if the <see cref="status"/> is <see cref="BillingReportStatus.failed"/>.
		/// </summary>
		/// <seealso cref="BillingReportStatus" />
		/// <override max-length="250" />
		public string? error;
		/// <summary>
		/// Summary contains totals per target for this billee
		/// </summary>
		public List<BillingReportSummary>? summary;
		/// <summary>
		/// Individual amounts per company, used to calculate the results of the report.
		/// </summary>
		public List<BillingReportBreakdown>? breakdown;
	}
}