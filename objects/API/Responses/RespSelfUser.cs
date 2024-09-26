using System.Collections.Generic;
using System.Runtime.Serialization;

namespace trakit.objects {
	/// <summary>
	/// Similar to the <see cref="User"/> object, but instead of the <see cref="RespSelfUserGeneral.contact"/>
	/// and <see cref="groups"/> properties being identifiers of other objects,
	/// the <see cref="Contact"/> and <see cref="UserGroup"/> objects are embedded within.
	/// </summary>
	public class RespSelfUser : RespSelfUserGeneral {
		/// <summary>
		/// Individual permission rules which override the <see cref="UserGroup"/> rules.
		/// </summary>
		[DataMember]
		public List<Permission> permissions;
		/// <summary>
		/// The list of <see cref="UserGroup"/>s to which this <see cref="User"/> belongs.
		/// </summary>
		[DataMember]
		public List<UserGroup> groups;
	}
}