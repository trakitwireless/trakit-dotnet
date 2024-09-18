using System;

namespace trakit.objects {
	/// <summary>
	/// An live snapshot a dashcam-enabled provider or asset.
	/// </summary>
	public class DashcamDataLive : DashcamBase {
		/// <summary>
		/// The type of data being stored.
		/// </summary>
		/// <override value="image" />
		public readonly DashcamDataType kind = DashcamDataType.image;
		/// <summary>
		/// Timestamp of this live camera image.
		/// </summary>
		public DateTime dts;
	}
}