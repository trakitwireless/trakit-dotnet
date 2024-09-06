using System;
using System.Collections.Generic;

namespace trakit.objects {
	/// <summary>
	/// The current state of an asset's <see cref="DispatchJob"/> route progress.
	/// </summary>
	/// <category>Dispatch</category>
	/// <override>
	/// <property name="tasks" type="System.Array" obsolete="true">
	/// <summary>The current list of tasks assigned to this asset.</summary>
	/// <values type="Vorgon.DispatchTask" />
	/// </property>
	/// </override>
	public class AssetDispatch : Subscribable, IIdUlong, IBelongCompany {
		/// <summary>
		/// Unique identifier of this asset.
		/// </summary>
		/// <seealso cref="Asset.id" />
		public ulong id { get; set; }
		/// <summary>
		/// The company to which this asset belongs.
		/// </summary>
		/// <seealso cref="Company.id" />
		public ulong company { get; set; }
		/// <summary>
		/// The current list of <see cref="DispatchJob"/>s assigned to the asset.
		/// </summary>
		/// <seealso cref="DispatchJob"/>
		public List<ulong> jobs;
		/// <summary>
		/// Driving directions and route path details.
		/// </summary>
		public List<DispatchDirection> directions;
		/// <summary>
		/// Timestamp from the last update to this object, or an assigned <see cref="DispatchJob"/>.
		/// </summary>
		/// <summary>
		/// Timestamp from the last update to this <see cref="AssetDispatch"/> by a <see cref="User"/>, <see cref="Machine"/>, <see cref="Asset"/>, or an assigned <see cref="DispatchJob"/>.
		/// </summary>
		public DateTime lastDispatched;
	}
}