﻿namespace trakit.objects {
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
}