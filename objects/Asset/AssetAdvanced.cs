using System;
using System.Collections.Generic;

namespace trakit.objects {
	/// <summary>
	/// The kinds of interactions had with a Place.
	/// </summary>
	/// <category>Assets</category>
	public enum AssetPlaceStatusType : byte {
		/// <summary>
		/// Occurs when an asset is outside a Place, then goes inside the boundary.
		/// </summary>
		enter,
		/// <summary>
		/// Occurs when the asset was inside the boundary before, and is still inside the boundary now.
		/// </summary>
		inside,
		/// <summary>
		/// Occurs when an asset was inside the boundary of a Place, but then moves outside the boundary.
		/// </summary>
		exit,
	}

	/// <summary>
	/// Often changing details about a thing.
	/// </summary>
	/// <category>Assets</category>
	public class AssetAdvanced : Subscribable, IIdUlong, IBelongCompany {
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
	}
	/// <summary>
	/// Often changing details about a vehicle.
	/// </summary>
	/// <category>Assets</category>
	public class VehicleAdvanced : AssetAdvanced {
		/// <summary>
		/// The cumulative duration that the vehicle's engine has been running (in decimal hours).
		/// </summary>
		public double engineHours;
	}

	/// <summary>
	/// An attribute given to an asset by a behaviour script.
	/// </summary>
	/// <category>Assets</category>
	public struct AssetAttribute {
		/// <summary>
		/// Display name of the attribute.
		/// </summary>
		/// <override max-length="100" />
		public string name;
		/// <summary>
		/// Computed/contextual value from the behaviour.  Like "3.76 volts" or "on".
		/// </summary>
		public string simple;
		/// <summary>
		/// Parse-able/formatted string for complex display.  May contain HTML.
		/// </summary>
		public string complex;
		/// <summary>
		/// Raw value like 3.76 (volts) or true (on).
		/// </summary>
		public object raw;
		/// <summary>
		/// Text representation of unit like "°C" or "Km".
		/// </summary>
		/// <seealso cref="Units" />
		public string unit;
		/// <summary>
		/// The device which provided  this attribute.
		/// </summary>
		/// <seealso cref="Provider.id" />
		public string provider;
		/// <summary>
		/// The related asset which provided this attribute.
		/// </summary>
		/// <seealso cref="Asset.id" />
		public ulong asset;
		/// <summary>
		/// Date/time stamp from when this attribute was recorded (or reported) by the device.
		/// </summary>
		public DateTime dts;
		/// <summary>
		/// When false, indicates that this attribute is used by an internal system and should be left untouched.
		/// </summary>
		public bool global;
	}
	/// <summary>
	/// A simple status for each place an Asset visits.
	/// </summary>
	/// <category>Assets</category>
	public class AssetPlaceStatus {
		/// <summary>
		/// The kind of interaction.
		/// </summary>
		public AssetPlaceStatusType kind;
		/// <summary>
		/// The date/time stamp for when the Asset first began interacting with the Place.
		/// </summary>
		public DateTime enter;
		/// <summary>
		/// The most recent date/time stamp for the interaction.
		/// </summary>
		public DateTime latest;
	}
}