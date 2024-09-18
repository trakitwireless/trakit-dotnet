using System;
using System.Collections.Generic;

namespace trakit.objects {
	/// <summary>
	/// The full details of an Asset, containing all the properties from the <see cref="AssetGeneral"/> and <see cref="AssetAdvanced"/> objects.
	/// </summary>
	public class Asset : Subscribable, IIdUlong, INamed, IIconic, IBelongCompany, ILabelled, IPictured, ISuspendable, IDeletable {
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
		/// Type of asset.
		/// </summary>
		public AssetType kind { get; set; }
		/// <summary>
		/// This thing's name.
		/// </summary>
		/// <override max-length="100" />
		public string name { get; set; }
		/// <summary>
		/// The icon that represents this asset on the map and in lists.
		/// </summary>
		/// <seealso cref="Icon.id" />
		public ulong icon { get; set; }
		/// <summary>
		/// Notes about it.
		/// </summary>
		public string notes { get; set; }
		/// <summary>
		/// Codified label names.
		/// </summary>
		/// <override>
		/// <values format="codified">
		/// <seealso cref="LabelStyle.code" />
		/// </values>
		/// </override>
		public List<string> labels { get; set; }
		/// <summary>
		/// A list of photos of this thing.
		/// </summary>
		/// <override>
		/// <values>
		/// <seealso cref="Picture.id" />
		/// </values>
		/// </override>
		public List<ulong> pictures { get; set; }
		/// <summary>
		/// The fall-back address which is used to send Messages if the asset is a Person and has no Contact phone or email.
		/// </summary>
		/// <override max-length="254" />
		public string messagingAddress;
		/// <summary>
		/// Name/value collections of custom fields used to refer to external systems.
		/// </summary>
		/// <override max-count="10">
		/// <keys max-length="20" />
		/// <values max-length="100" />
		/// </override>
		public Dictionary<string, string> references;

		/// <summary>
		/// The things GPS coordinates including speed, bearing, and street information.
		/// </summary>
		public Position position;
		/// <summary>
		/// The cumulative distance travelled in kilometres.
		/// </summary>
		public double odometer;
		/// <summary>
		/// The codified status tag names.
		/// </summary>
		/// <override>
		/// <values format="codified">
		/// <seealso cref="LabelStyle.code" />
		/// </values>
		/// </override>
		public List<string> tags;
		/// <summary>
		/// A list of attributes given to this asset by the connection device such as wiring state, VBus, etc.
		/// </summary>
		/// <override>
		/// <keys format="codified">
		/// <seealso cref="AssetAttribute.name" />
		/// </keys>
		/// </override>
		public Dictionary<string, AssetAttribute> attributes;
		/// <summary>
		/// The list of devices providing events for this asset.
		/// </summary>
		/// <override readonly="true">
		/// <values>
		/// <seealso cref="Provider.id" />
		/// </values>
		/// </override>
		public List<string> providers;
		/// <summary>
		/// A list of assets related to this one; like a Person for a Vehicle (driver).
		/// </summary>
		/// <override>
		/// <values>
		/// <seealso cref="Asset.id" />
		/// </values>
		/// </override>
		public List<ulong> relationships;
		/// <summary>
		/// The current state of this asset's interaction with known Places.
		/// </summary>
		/// <override>
		/// <keys>
		/// <seealso cref="Place.id" />
		/// </keys>
		/// </override>
		public Dictionary<ulong, AssetPlaceStatus> places;

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
		/// Timestamp from the last update to this <see cref="AssetDispatch"/> by a <see cref="User"/>, <see cref="Machine"/>, <see cref="Asset"/>, or an assigned <see cref="DispatchJob"/>.
		/// </summary>
		public DateTime lastDispatched;

		/// <summary>
		/// Indicates whether this object was deleted.
		/// </summary>
		public bool? deleted { get; set; }
		/// <summary>
		/// Indicates whether this object is suspended from event processing.
		/// </summary>
		public bool? suspended { get; set; }
		/// <summary>
		/// Timestamp from the action that deleted or suspended this object.
		/// </summary>
		public DateTime? since { get; set; }
	}
}