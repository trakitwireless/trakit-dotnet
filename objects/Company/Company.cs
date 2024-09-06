using System.Collections.Generic;
using System.Linq;

namespace trakit.objects {
	/// <summary>
	/// The full company object which contains all fields.
	/// </summary>
	/// <category>Companies</category>
	/// <override complex="true">
	/// <merge type="Vorgon.CompanyGeneral" />
	/// <merge type="Vorgon.CompanyDirectory" />
	/// <merge type="Vorgon.CompanyLabels" />
	/// <merge type="Vorgon.CompanyPolicies" />
	/// </override>
	public class Company : IIdUlong, IAmCompany {
		/// <summary>
		/// General information like name and notes.
		/// </summary>
		/// <override skip="true" />
		public CompanyGeneral general;
		/// <summary>
		/// The company directory is for listing contact information to outsiders.
		/// ie: Technical contact, Billing address, etc...
		/// </summary>
		/// <override skip="true" />
		public CompanyDirectory directory;
		/// <summary>
		/// Collection of styles to use for labels and tags.
		/// </summary>
		/// <override skip="true" />
		public CompanyStyles styles;
		/// <summary>
		/// The policies to use for sessions and passwords.
		/// </summary>
		/// <override skip="true" />
		public CompanyPolicies policies;
		/// <summary>
		/// A list of user groups that belong to this company.
		/// A user can only belong to groups from their own company.
		/// </summary>
		public List<UserGroup> userGroups;
		/// <summary>
		/// If this company is a reseller, then they have their own theme, support and billing information.
		/// </summary>
		public CompanyReseller reseller;

		/// <summary>
		/// Unique identifier of the Company.
		/// </summary>
		/// <override readonly="true" />
		public ulong id => this.general?.id
						?? this.styles?.id
						?? this.policies?.id
						?? this.reseller?.id
						?? this.userGroups?.FirstOrDefault()?.id
						?? this.directory.id;
		/// <summary>
		/// The unique identifier of this company's parent organization.
		/// </summary>
		/// <seealso cref="Company.id" />
		/// <override readonly="true" />
		public ulong parent {
			get => this.general?.parent
				?? this.styles?.parent
				?? this.policies?.parent
				?? this.reseller?.parent
				?? this.directory.parent;
			set {
				if (this.general != null) this.general.parent = value;
				if (this.styles != null) this.styles.parent = value;
				if (this.policies != null) this.policies.parent = value;
				if (this.reseller != null) this.reseller.parent = value;
				if (this.directory != null) this.directory.parent = value;
			}
		}
		/// <summary>
		/// Object version keys used to validate synchronization for all object properties.
		/// </summary>
		/// <override name="v" count="6" readonly="true">
		/// <element key="0">The first element is for the general properties</element>
		/// <element key="1">The second element is not used (yet)</element>
		/// <element key="2">The third element is not used (yet)</element>
		/// <element key="3">The fourth element is for the style properties</element>
		/// <element key="4">The fifth element is for the policy properties</element>
		/// <element key="5">The sixth element is for the reseller properties</element>
		/// </override>
		public int[] version => new int[] {
			(int?)this.general?.version[0] ?? -1,
			-1,
			(int?)this.directory?.version[0] ?? -1,
			(int?)this.styles?.version[0] ?? -1,
			(int?)this.policies?.version[0] ?? -1,
			(int?)this.reseller?.version[0] ?? -1,
		};
	}
}