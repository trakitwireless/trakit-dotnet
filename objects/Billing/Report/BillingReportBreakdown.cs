using System.Collections.Generic;

namespace trakit.objects {
	/// <summary>
	/// Billing breakdown per target company.
	/// </summary>
	/// <category>Billing</category>
	public class BillingReportBreakdown {
		/// <summary>
		/// The target company to which this breakdown instance belongs.
		/// </summary>
		/// <seealso cref="Company.id" />
		public ulong target { get; set; }
		/// <summary>
		/// Individual amounts billed per targeted assets.
		/// </summary>
		public List<BillingReportServiceBreakdown> services;
		/// <summary>
		/// Individual amounts for licensing per targeted providers.
		/// </summary>
		public List<BillingReportLicenseBreakdown> licenses;
	}
}