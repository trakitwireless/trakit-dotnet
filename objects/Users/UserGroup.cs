using System.Collections.Generic;

namespace trakit.objects {
	/// <summary>
	/// Members of a group (as set by a <see cref="User"/>'s <see cref="UserAdvanced.groups"/> or <see cref="Machine"/>'s <see cref="Machine.groups"/>)
	/// allow for easy administration of permissions and levels of access.
	/// </summary>
	/// <category>Users and Groups</category>
	public class UserGroup : Subscribable, IIdUlong, INamed, IDeletable, IBelongCompany {
		/// <summary>
		/// Unique identifier of this group.
		/// </summary>
		public ulong id { get; set; }
		/// <summary>
		/// The company to which this group belongs.
		/// </summary>
		/// <seealso cref="Company.id" />
		public ulong company { get; set; }
		/// <summary>
		/// A name given to this group.
		/// </summary>
		/// <override max-length="100" />
		public string name { get; set; }
		/// <summary>
		/// Notes about this group, and to whom this group should be applied.
		/// </summary>
		public string notes { get; set; }
		public bool deleted { get; set; }
		/// <summary>
		/// Permissions for this group.
		/// </summary>
		public List<Permission> permissions;
	}
}