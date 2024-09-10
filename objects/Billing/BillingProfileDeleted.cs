using System;

namespace trakit.objects {
	/// <summary>
	/// A profile used to generate billable orders for a customer.
	/// </summary>
	public class BillingProfileDeleted : Subscribable, IIdUlong, IDeletable, INamed, IBelongCompany {
		/// <summary>
		/// Unique identifier of this billing profile
		/// </summary>
		public ulong id { get; set; }
		/// <summary>
		/// Unique identifier of the Company that owns this profile and is sending the bill.
		/// </summary>
		/// <seealso cref="Company.id" />
		public ulong company { get; set; }
		/// <summary>
		/// The name for this profile
		/// </summary>
		/// <override max-length="254" />
		public string name { get; set; }
		/// <summary>
		/// Notes about the billing profile for the billee or target.
		/// </summary>
		/// <override max-length="1000" />
		public string notes { get; set; }
		/// <summary>
		/// This flag is always true.
		/// </summary>
		public bool deleted => true;
		/// <summary>
		/// Timestamp from the action that deleted this profile.
		/// </summary>
		public DateTime since { get; set; }
	}
}