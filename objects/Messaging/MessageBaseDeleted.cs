using System;

namespace trakit.objects {
	/// <summary>
	/// A base class for Alerts and Messages.
	/// </summary>
	public abstract class MessageBaseDeleted : Subscribable, IIdUlong, IDeletable, IBelongCompany, IBelongAsset {
		/// <summary>
		/// Unique identifier of this memo.
		/// </summary>
		public ulong id { get; set; }
		/// <summary>
		/// The company to which this memo belongs.
		/// </summary>
		/// <seealso cref="Company.id" />
		public ulong company { get; set; }
		/// <summary>
		/// The asset to which this message relates.
		/// </summary>
		/// <seealso cref="Asset.id" />
		public ulong asset { get; set; }
		/// <summary>
		/// This flag is always true.
		/// </summary>
		public bool deleted => true;
		/// <summary>
		/// Timestamp from the action that deleted this message.
		/// </summary>
		public DateTime since { get; set; }
	}
}