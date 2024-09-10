using System.Collections.Generic;
using System.Linq;

namespace trakit.objects {
	/// <summary>
	/// The full company object which contains all fields.
	/// </summary>
	public class Company : Subscribable, IIdUlong, INamed, IAmCompany {
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
		/// The organizational name.
		/// </summary>
		/// <override max-length="100" />
		public string name { get; set; }
		/// <summary>
		/// Notes.
		/// </summary>
		public string notes { get; set; }
		/// <summary>
		/// Name/value collections of custom fields used to refer to external systems.
		/// </summary>
		/// <override max-count="10">
		/// <keys max-length="20" />
		/// <values max-length="100" />
		/// </override>
		public Dictionary<string, string> references;

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

		/// <summary>
		/// The styles for labels added to Assets, Places, and other things.
		/// </summary>
		public Dictionary<string, LabelStyle> labels;
		/// <summary>
		/// The styles for status tags added to Assets.
		/// </summary>
		/// <override type="System.Collections.IDictionary">
		/// <keys type="System.String" format="codified">
		/// <seealso cref="LabelStyle.code" />
		/// </keys>
		/// <values type="Vorgon.LabelStyle" />
		/// </override>
		public Dictionary<string, LabelStyle> tags;

		/// <summary>
		/// The session lifetime policy.
		/// </summary>
		public SessionPolicy sessionPolicy;
		/// <summary>
		/// The password complexity and expiry policy.
		/// </summary>
		public PasswordPolicy passwordPolicy;

		/// <summary>
		/// A list of user groups that belong to this company.
		/// A user can only belong to groups from their own company.
		/// </summary>
		public List<UserGroup> userGroups;

		/// <summary>
		/// If this company is a reseller, then they have their own theme, support and billing information.
		/// </summary>
		public CompanyReseller reseller;
	}
}