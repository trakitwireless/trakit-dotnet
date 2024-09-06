using System;

namespace trakit.objects {
	/// <summary>
	/// The type of dashcam data being stored.
	/// </summary>
	/// <category>File Hosting</category>
	public enum DashcamDataType : byte {
		/// <summary>
		/// Unknown or other.
		/// </summary>
		unknown,
		/// <summary>
		/// Image
		/// </summary>
		image,
		/// <summary>
		/// Video
		/// </summary>
		video,
	}

	/// <summary>
	/// A base class for Dashcam meta-data.
	/// </summary>
	/// <category>File Hosting</category>
	public abstract class DashcamBase : IFileSize {
		/// <summary>
		/// Number bytes in the dashcam media file.
		/// </summary>
		public ulong bytes { get; set; }
		/// <summary>
		/// Resolution defined in pixels.
		/// </summary>
		public Size size;
		/// <summary>
		/// Unique identifier of the provider that sent the data.
		/// </summary>
		/// <seealso cref="Provider.id" />
		public string provider;
		/// <summary>
		/// Unique identifier of the company of the provider.
		/// </summary>
		/// <seealso cref="Company.id" />
		public ulong company;
		/// <summary>
		/// Unique identifier of the asset tied to the provider at the time.
		/// </summary>
		/// <seealso cref="Asset.id" />
		public ulong? asset;
		/// <summary>
		/// Number assigned to the camera that took the image/video.
		/// </summary>
		public byte camera;
		/// <summary>
		/// Latitude of the start of the resource.
		/// </summary>
		public double latitude;
		/// <summary>
		/// Longitude of the start of the resource.
		/// </summary>
		public double longitude;
		/// <summary>
		/// Speed of the start of the resource.
		/// </summary>
		public double speed;
		/// <summary>
		/// Heading of the start of the resource.
		/// </summary>
		public double heading;
		/// <summary>
		/// Altitude of the start of the resource.
		/// </summary>
		public double altitude;
	}

	/// <summary>
	/// An image or video received from a dashcam-enabled provider or asset.
	/// </summary>
	/// <category>File Hosting</category>
	public class DashcamData : DashcamBase {
		/// <summary>
		/// Unique identifier of this resource.
		/// </summary>
		/// <override format="guid" />
		public string guid;
		/// <summary>
		/// The type of data being stored.
		/// </summary>
		public DashcamDataType kind;
		/// <summary>
		/// For <see cref="DashcamDataType.video"/> media files, this indicates the frames-per-second.
		/// </summary>
		public float? fps;
		/// <summary>
		/// Timestamp of when this resource started.
		/// For <see cref="DashcamDataType.image"/> media files, the start and end are the same.
		/// </summary>
		public DateTime start;
		/// <summary>
		/// Timestamp of when this resource ended.
		/// For <see cref="DashcamDataType.image"/> media files, the start and end are the same.
		/// </summary>
		public DateTime end;
		/// <summary>
		/// For <see cref="DashcamDataType.video"/> media files, the duration of the video clip.
		/// </summary>
		public TimeSpan duration => this.end - this.start;
		/// <summary>
		/// The reason why we're saving this image/video. Or the event name that triggered it.
		/// </summary>
		public string eventName;
	}

	/// <summary>
	/// An live snapshot a dashcam-enabled provider or asset.
	/// </summary>
	/// <category>File Hosting</category>
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