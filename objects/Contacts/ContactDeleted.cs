using System;

namespace trakit.objects {
	/// <summary>
	/// Contact information.
	/// </summary>
	public class ContactDeleted : Subscribable, IIdUlong,  IDeletable, INamed, IBelongCompany {
		/// <summary>
		/// Unique identifier of this contact.
		/// </summary>
		public ulong id { get; set; }
		/// <summary>
		/// The company to which this contact belongs
		/// </summary>
		/// <seealso cref="Company.id" />
		public ulong company { get; set; }
		/// <summary>
		/// The person's name
		/// </summary>
		/// <override max-length="100" />
		public string name { get; set; }
		/// <summary>
		/// Notes about this person.
		/// </summary>
		public string notes { get; set; }
		/// <summary>
		/// This flag is always true.
		/// </summary>
		public bool deleted => true;
		/// <summary>
		/// Timestamp from the action that deleted this contact.
		/// </summary>
		public DateTime since { get; set; }
	}
}