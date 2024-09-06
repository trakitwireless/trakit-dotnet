using System.Collections.Generic;

namespace trakit.objects {
	/// <summary>
	/// The list of Contacts from this and other companies broken down by contact role.
	/// </summary>
	/// <category>Companies</category>
	/// <override skip="true" />
	public class CompanyDirectory : Subscribable, IIdUlong, IAmCompany {
		/// <summary>
		/// Unique identifier of the Company.
		/// </summary>
		/// <seealso cref="Company.id" />
		public ulong id { get; set; }
		/// <summary>
		/// The unique identifier of this company's parent organization.
		/// </summary>
		/// <seealso cref="Company.id" />
		public ulong parent { get; set; }
		/// <summary>
		/// The list of Contacts from this and other companies broken down by contact role.
		/// </summary>
		/// <override>
		/// <values>
		/// <values>
		/// <seealso cref="Contact.id" />
		/// </values>
		/// </values>
		/// </override>
		public Dictionary<string, List<ulong>> directory;
	}
}