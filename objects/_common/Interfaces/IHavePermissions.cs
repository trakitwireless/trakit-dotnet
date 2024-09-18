using System.Collections.Generic;

namespace trakit.objects {
	/// <summary>
	/// This interface exists so that I can work with Machine and UserAdvanced objects the same way.
	/// </summary>
	public interface IHavePermissions {
		/// <summary>
		/// A list of groups to which this object.
		/// </summary>
		/// <seealso cref="UserGroup.id" />
		List<ulong> groups { get; }
		/// <summary>
		/// Permission rules which override the group rules.
		/// </summary>
		List<Permission> permissions { get; }
	}
}