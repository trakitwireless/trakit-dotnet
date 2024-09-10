using System;

namespace trakit.objects {
	/// <summary>
	/// A completed form submitted by a <see cref="User"/> or <see cref="Asset"/>.
	/// </summary>
	public class FormResultDeleted : Subscribable, IIdUlong, IBelongCompany, IDeletable {
		/// <summary>
		/// Unique identifier of this form.
		/// </summary>
		public ulong id { get; set; }
		/// <summary>
		/// The <see cref="Company"/> to which this form belongs.
		/// </summary>
		/// <seealso cref="Company.id" />
		public ulong company { get; set; }
		/// <summary>
		/// This flag is always true.
		/// </summary>
		public bool deleted => true;
		/// <summary>
		/// Timestamp from the action that deleted this asset.
		/// </summary>
		public DateTime since { get; set; }
	}
}