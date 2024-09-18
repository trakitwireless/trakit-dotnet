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
}