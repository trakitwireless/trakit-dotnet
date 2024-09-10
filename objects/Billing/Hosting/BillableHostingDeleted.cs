using System;

namespace trakit.objects {
	/// <summary>
	/// Hosted things share a lot of common attributes.
	/// </summary>
	public abstract class BillableHostingDeleted : Subscribable, IIdUlong, INamed, IBelongBillingProfile, IBelongCompany, IDeletable {
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
		/// The name of this billing rule.
		/// </summary>
		/// <override max-length="254" />
		public string name { get; set; }
		/// <summary>
		/// Notes about billing this rule.
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