using System;
using System.Collections.Generic;

namespace trakit.objects {
	/// <summary>
	/// The four supported types of trackable things.
	/// </summary>
	public enum AssetType : byte {
		/// <summary>
		/// Generic thing.
		/// </summary>
		asset,
		/// <summary>
		/// Human (or alien) Person.
		/// </summary>
		person,
		/// <summary>
		/// A towed vehicle without an engine.
		/// </summary>
		trailer,
		/// <summary>
		/// A vehicle that moves with its own power.
		/// </summary>
		vehicle,
	}

	/// <summary>
	/// The full details of an Asset, containing all the properties from the <see cref="AssetGeneral"/> and <see cref="AssetAdvanced"/> objects.
	/// </summary>
	public class Asset : Subscribable, IIdUlong, INamed, IIconic, IBelongCompany, ILabelled, IPictured {
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
	}

	/// <summary>
	/// The full details of a Person, containing all the properties from the <see cref="PersonGeneral"/> and <see cref="AssetAdvanced"/> objects.
	/// </summary>
	public class Person : Asset {
		/// <summary>
		/// A reference to their Company's Contact information.
		/// </summary>
		/// <seealso cref="Contact.id" />
		public ulong contact;
	}

	/// <summary>
	/// The full details of a Trailer, containing all the properties from the <see cref="TrailerGeneral"/> and <see cref="AssetAdvanced"/> objects.
	/// </summary>
	public class Trailer : Asset {
		/// <summary>
		/// The license plate.
		/// </summary>
		/// <override max-length="50" />
		public string plate;
		/// <summary>
		/// Manufacturer's unique identification number for this trailer.
		/// </summary>
		/// <override max-length="50" />
		public string serial;
		/// <summary>
		/// Manufacturer's name.
		/// </summary>
		/// <override max-length="50" />
		public string make;
		/// <summary>
		/// Manufacturer's model name/number.
		/// </summary>
		/// <override max-length="50" />
		public string model;
		/// <summary>
		/// Year of manufacturing.
		/// </summary>
		public ushort year;
		/// <summary>
		/// Primary colour of the trailer (given in 24bit hex; #RRGGBB)
		/// </summary>
		/// <override max-length="22" format="colour" />
		public string colour;
	}

	/// <summary>
	/// The full details of a Vehicle, containing all the properties from the <see cref="VehicleGeneral"/> and <see cref="VehicleAdvanced"/> objects.
	/// </summary>
	public class Vehicle : Asset {
		/// <summary>
		/// Manufacturer's unique identification number (Vehicle Identification Number).
		/// </summary>
		/// <override max-length="50" />
		public string vin;
		/// <summary>
		/// The license plate.
		/// </summary>
		/// <override max-length="50" />
		public string plate;
		/// <summary>
		/// Manufacturer's name.
		/// </summary>
		/// <override max-length="50" />
		public string make;
		/// <summary>
		/// Manufacturer's model name/number.
		/// </summary>
		/// <override max-length="50" />
		public string model;
		/// <summary>
		/// Year of manufacturing.
		/// </summary>
		public ushort year;
		/// <summary>
		/// Primary colour of the vehicle (given in 24bit hex; #RRGGBB)
		/// </summary>
		/// <override max-length="22" format="colour" />
		public string colour;

		/// <summary>
		/// The cumulative duration that the vehicle's engine has been running (in decimal hours).
		/// </summary>
		public double engineHours;
	}
}