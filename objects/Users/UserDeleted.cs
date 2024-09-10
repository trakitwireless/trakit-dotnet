using System;

namespace trakit.objects {
	/// <summary>
	/// A grouping of credentials, information, preferences, and permissions for a person or machine to login to the system and access its resources.
	/// </summary>
	public class UserDeleted : Subscribable, IDeletable, IBelongCompany {
		/// <summary>
		/// The unique public email address used to access the system.
		/// </summary>
		/// <seealso cref="User.login" />
		/// <override min-length="6" max-length="254" format="email" />
		public string login { get; set; }
		/// <summary>
		/// The company to which this user belongs.
		/// </summary>
		/// <seealso cref="Company.id" />
		public ulong company { get; set; }
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