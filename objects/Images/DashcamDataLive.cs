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

		// IRequestable
		/// <summary>
		/// A combination of the asset, provider, and camera number.
		/// </summary>
		/// <returns></returns>
		public override string getKey() => (this.asset?.ToString() ?? string.Empty)
									+ (this.provider?.ToString() ?? string.Empty)
									+ "-" + this.camera;
	}
}