using System.Collections.Generic;

namespace trakit.objects {
	/// <summary>
	/// An image stored by the system.
	/// </summary>
	public class Picture : Subscribable, IIdUlong, INamed,  IBelongCompany, IFileSize {
		/// <summary>
		/// Unique identifier of this image.
		/// </summary>
		public ulong id { get; set; }
		/// <summary>
		/// The company to which this image belongs.
		/// </summary>
		/// <seealso cref="Company.id" />
		public ulong company { get; set; }
		/// <summary>
		/// The file name of this image.
		/// </summary>
		/// <override max-length="100" />
		public string name { get; set; }
		/// <summary>
		/// Notes about this image.
		/// </summary>
		public string notes { get; set; }
		/// <summary>
		/// The URL/path to find this image.
		/// </summary>
		/// <override max-length="200" />
		public string src { get; set; }
		/// <summary>
		/// Resolution defined in pixels.
		/// </summary>
		public Size size { get; set; }
		/// <summary>
		/// A list of focal points in the images like faces.
		/// </summary>
		public List<Square> focals;
		/// <summary>
		/// The file-size on the disk.
		/// </summary>
		public ulong bytes { get; set; }
		/// <summary>
		/// A count of the times this image was used for something (asset, contact, task, etc).
		/// </summary>
		public uint uses;
	}
}