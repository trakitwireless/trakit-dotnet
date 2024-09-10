using System;
using System.Collections.Generic;

namespace trakit.objects {
	/// <summary>
	/// A file stored temporarily by the system.
	/// </summary>
	public class Document : Subscribable, IIdUlong, INamed, IBelongCompany, IFileSize {
		/// <summary>
		/// Unique identifier of this file.
		/// </summary>
		public ulong id { get; set; }
		/// <summary>
		/// The company to which this file belongs.
		/// </summary>
		/// <seealso cref="Company.id" />
		public ulong company { get; set; }
		/// <summary>
		/// The file name of this file.
		/// </summary>
		/// <override max-length="100" />
		public string name { get; set; }
		/// <summary>
		/// Notes about this file.
		/// </summary>
		public string notes { get; set; }
		/// <summary>
		/// The URL/path to find this file.
		/// </summary>
		/// <override max-length="200" />
		public string src { get; set; }
		/// <summary>
		/// The file-size on the disk.
		/// </summary>
		public ulong bytes { get; set; }
		/// <summary>
		/// The MIME type of the file.
		/// </summary>
		/// <override max-length="50" />
		public string mime { get; set; }
		/// <summary>
		/// The date and time this fill will be automatically purged from our system.
		/// </summary>
		public DateTime expiry;
		/// <summary>
		/// Name/value collections of custom fields used to refer to external systems.
		/// </summary>
		/// <override max-count="10">
		/// <keys max-length="20" />
		/// <values max-length="100" />
		/// </override>
		public Dictionary<string, string> references;
	}
}