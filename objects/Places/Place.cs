using System;
using System.Collections.Generic;

namespace trakit.objects {
	/// <summary>
	/// The types of geography the system supports
	/// </summary>
	/// <override name="PlaceType"/>
	public enum PlaceType : byte {
		/// <summary>
		/// A lat/long coordinate pair.
		/// Places of this type do not contain the <see cref="Vorgon.PlaceGeneral.radius"/> or <see cref="Vorgon.PlaceGeneral.shape"/> keys.
		/// </summary>
		point,
		/// <summary>
		/// Defined as a radius around a lat/long pair used to create a circular boundary.
		/// Places of this type do not contain the <see cref="Vorgon.PlaceGeneral.shape"/> key.
		/// </summary>
		radial,
		/// <summary>
		/// The <see cref="Vorgon.PlaceGeneral.shape"/> is an array of lat/long coordinates used to create a boundary.
		/// Places of this type do not contain the <see cref="Vorgon.PlaceGeneral.radius"/> key.
		/// </summary>
		polygon,
		/// <summary>
		/// The <see cref="Vorgon.PlaceGeneral.shape"/> is an array of two lat/long coordinates defined as north-east and south-west corners.
		/// Places of this type do not contain the <see cref="Vorgon.PlaceGeneral.radius"/> key.
		/// </summary>
		rectangle,
	}

	/// <summary>
	/// A POI (point-of-interest) saved to the system to help determine an asset's real-world position.
	/// </summary>
	/// <override complex="true">
	/// <property name="anchor" type="Vorgon.LatLng">
	/// <summary>
	/// A central point of the shape.
	/// This is the exact centre of a <see cref="PlaceType.radial"/> and <see cref="PlaceType.point"/> shaped places, and the location of the pin on the map for all types.
	/// When routing, <see cref="PlaceType.polygon"/> and <see cref="PlaceType.rectangle"/> shapes use the anchor as the location within the place for deliveries.
	/// </summary>
	/// </property>
	/// <property name="radius" type="System.Double" nullable="true">
	/// <summary>
	/// This member is only present for <see cref="PlaceType.radial"/> shapes, and is the radius in meters from the centre anchor.
	/// </summary>
	/// </property>
	/// </override>
	public class Place : Subscribable, IIdUlong, INamed, IIconic, IBelongCompany, ILabelled, IPictured, IDeletable {
		/// <summary>
		/// Unique identifier of this POI.
		/// </summary>
		public ulong id { get; set; }
		/// <summary>
		/// The company to which this POI belongs.
		/// </summary>
		/// <seealso cref="Company.id" />
		public ulong company { get; set; }
		/// <summary>
		/// The kind of geography represented by this POI.
		/// </summary>
		public PlaceType kind;
		/// <summary>
		/// POI's common name instead of street address.
		/// </summary>
		/// <override max-length="100" />
		public string name { get; set; }
		/// <summary>
		/// Full street address including province/state, country, and postal/zip code.
		/// </summary>
		/// <override max-length="200" />
		public string address;
		/// <summary>
		/// The icon used to display this POI in lists and on the map.
		/// </summary>
		/// <seealso cref="Icon.id" />
		public ulong icon { get; set; }
		/// <summary>
		/// Notes!
		/// </summary>
		public string notes { get; set; }
		/// <summary>
		/// The codified names of labels
		/// </summary>
		/// <override>
		/// <values format="codified">
		/// <seealso cref="LabelStyle.code" />
		/// </values>
		/// </override>
		public List<string> labels { get; set; }
		/// <summary>
		/// The fill colour given to this place for easy visual identification on the map (given in 24bit hex; #RRGGBB)
		/// </summary>
		/// <override max-length="22" format="colour" />
		public string colour;
		/// <summary>
		/// Images of this POI.
		/// </summary>
		/// <override>
		/// <values>
		/// <seealso cref="Picture.id" />
		/// </values>
		/// </override>
		public List<ulong> pictures { get; set; }
		/// <summary>
		/// A custom field used to refer to an external system.
		/// </summary>
		/// <override max-length="100" />
		public string reference;

		/// <summary>
		/// Central lat/long coordinates.
		/// </summary>
		public LatLng anchor;
		/// <summary>
		/// Boundary threshold (in meters)
		/// </summary>
		public double? radius;
		/// <summary>
		/// A list of points forming a non-self-intersecting polygon.
		/// </summary>
		public List<LatLng>? points;

		/// <summary>
		/// Indicates whether this object was deleted.
		/// </summary>
		public bool? deleted { get; set; }
		/// <summary>
		/// Timestamp from the action that deleted or suspended this object.
		/// </summary>
		public DateTime? since { get; set; }
	}
}