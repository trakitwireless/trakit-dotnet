using System;

namespace trakit.objects {
	/// <summary>
	/// A coordinate on the globe
	/// </summary>
	public class LatLng {
		/// <summary>
		/// Let's consider the zero-zero coordinates to be invalid.
		/// </summary>
		public static LatLng INVALID => new LatLng() { lat = 0, lng = 0 };

		/// <summary>
		/// Latitude
		/// </summary>
		public double lat;
		/// <summary>
		/// Longitude
		/// </summary>
		public double lng;
	}

	/// <summary>
	/// A boundary on the globe
	/// </summary>
	public class LatLngBounds {
		/// <summary>
		/// Northern latitude
		/// </summary>
		public double north;
		/// <summary>
		/// Eastern longitude
		/// </summary>
		public double east;
		/// <summary>
		/// Southern latitude
		/// </summary>
		public double south;
		/// <summary>
		/// Western longitude
		/// </summary>
		public double west;
	}

	/// <summary>
	/// GPS position information
	/// </summary>
	public class Position {
		/// <summary>Latitude</summary>
		public double? lat;
		/// <summary>Longitude</summary>
		public double? lng;
		/// <summary>Speed</summary>
		public double? speed;
		/// <summary>Direction of travel</summary>
		public ushort? bearing;
		/// <summary>Distance in meters from the sea level</summary>
		public double? altitude;
		/// <summary>Threshold in meters for the accuracy of a position</summary>
		public uint? accuracy;
		/// <summary>The Date/Time of the GPS reading</summary>
		public DateTime dts;
		/// <summary>A better description of the current road-segment</summary>
		public StreetAddress streetAddress;
		/// <summary>The posted speed limit for the road segment</summary>
		public double? speedLimit;
		/// <summary>Provider Identifier</summary>
		public string origin;
		/// <summary>The road segment description</summary>
		public string address => this.streetAddress?.ToString() ?? "";
	}

	/// <summary>
	/// A road segment description
	/// </summary>
	public class StreetAddress {
		/// <summary>
		/// House number.
		/// </summary>
		public string number;
		/// <summary>
		/// Full street name.
		/// </summary>
		public string street;
		/// <summary>
		/// City name.
		/// </summary>
		public string city;
		/// <summary>
		/// Region name.
		/// </summary>
		public string region;
		/// <summary>
		/// Province or state code.
		/// Codes should be a value from ISO 3166-2.
		/// </summary>
		/// <override length="2" />
		public string province;
		/// <summary>
		/// Country code.
		/// Codes should be a value from ISO 3166-1 alpha-2.
		/// </summary>
		/// <override length="2" />
		public string country;
		/// <summary>
		/// Postal or zip code.
		/// </summary>
		public string postal;
		/// <summary>
		/// Indicates that there is a toll for the current road segment.
		/// </summary>
		public bool isToll;
	}
}