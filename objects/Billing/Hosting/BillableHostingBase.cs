﻿using System;

namespace trakit.objects {
	/// <summary>
	/// Hosted things share a lot of common attributes.
	/// </summary>
	public abstract class BillableHostingBase : Subscribable, IIdUlong, IBelongBillingProfile, IBelongCompany {
		/// <summary>
		/// Unique identifier of this hosting rule.
		/// </summary>
		public ulong id { get; set; }
		/// <summary>
		/// Unique identifier of the Company that owns this hosting rule.
		/// </summary>
		/// <seealso cref="Company.id" />
		public ulong company { get; set; }
		/// <summary>
		/// Unique identifier of this rule's billing profile.
		/// </summary>
		/// <seealso cref="BillingProfile.id" />
		public ulong profile { get; set; }
		/// <summary>
		/// This flag is always true.
		/// </summary>
		public bool deleted => true;
		/// <summary>
		/// Timestamp from the action that deleted this rule.
		/// </summary>
		public DateTime since { get; set; }
	}
}