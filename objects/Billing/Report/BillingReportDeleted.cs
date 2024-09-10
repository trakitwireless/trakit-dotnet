﻿using System;

namespace trakit.objects {
	/// <summary>
	/// Report generated per billee company.
	/// </summary>
	public class BillingReportDeleted : Subscribable, IIdUlong, IDeletable, INamed, IBelongCompany, IBelongBillingProfile {
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
		/// This flag is always true.
		/// </summary>
		public bool deleted => true;
		/// <summary>
		/// Timestamp from the action that deleted this asset.
		/// </summary>
		public DateTime since { get; set; }
	}
}