using System;
using System.Collections.Generic;

namespace trakit.objects {
	/// <summary>
	/// Used for invoices.
	/// </summary>
	public enum BillingCurrency : byte {
		/// <summary>
		/// Canadian dollars
		/// </summary>
		CAD,
		/// <summary>
		/// American dollars
		/// </summary>
		USD,
		/// <summary>
		/// Eurozone currency
		/// </summary>
		EURO,
	}
	/// <summary>
	/// The type of repeating cycle used for generating bills.
	/// </summary>
	public enum BillingCycle : byte {
		/// <summary>
		/// Once a month
		/// </summary>
		monthly,
		/// <summary>
		/// Every three months
		/// </summary>
		quarterly,
		/// <summary>
		/// Once per year
		/// </summary>
		annually,
	}

	/// <summary>
	/// A profile used to generate billable orders for a customer.
	/// </summary>
	public class BillingProfile : Subscribable, IIdUlong, INamed, IBelongCompany {
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
		/// Unique identifier of the Company to which this rule pertains.
		/// </summary>
		/// <seealso cref="Company.id" />
		public ulong target { get; set; }
		/// <summary>
		/// Unique identifier of the Company receiving the bill.
		/// Most of the time, this value is the same as the target.
		/// </summary>
		/// <seealso cref="Company.id" />
		public ulong billee { get; set; }
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
		/// SMS messaging tiers
		/// </summary>
		public List<BillableSmsProfile> messages;
		/// <summary>
		/// Repeating cycle used for generating bills
		/// </summary>
		public BillingCycle cycle;
		/// <summary>
		/// When is the first day of the billing cycle
		/// </summary>
		public DateTime cycleStart;
		/// <summary>
		/// When should the cycle end (customer cancelled)
		/// </summary>
		public DateTime? cycleEnd;
		/// <summary>
		/// Pro-rated, or post-dated.
		/// </summary>
		public bool cyclePostDated;
		/// <summary>
		/// kind of money
		/// </summary>
		public BillingCurrency currency;
		/// <summary>
		/// Are the Google services available to be proxied by the service?
		/// </summary>
		public bool googleServicesEnabled;
	}
	/// <summary>
	/// Description of a tiered SMS messaging limit
	/// </summary>
	public class BillableSmsProfile {
		/// <summary>
		/// The maximum number of messages sent per cycle
		/// </summary>
		public uint limit;
		/// <summary>
		/// Cost per SMS message sent.
		/// Received messages are free.
		/// </summary>
		public double amount;
	}
}