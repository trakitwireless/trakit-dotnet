using System;

namespace trakit.objects {
	/// <summary>
	/// The temporary reference to a device whose ownership is pending.
	/// </summary>
	public class ProviderRegistrationDeleted : INamed, IBelongCompany, IDeletable {
		/// <summary>
		/// A unique six digit code.
		/// </summary>
		/// <override length="6" />
		public string code;
		/// <summary>
		/// The company to which the device will belong.
		/// </summary>
		/// <seealso cref="Company.id" />
		public ulong company { get; set; }
		/// <summary>
		/// A nickname given to the device once it has been provisioned.
		/// </summary>
		/// <override max-length="100" />
		public string name { get; set; }
		/// <summary>
		/// Notes!
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