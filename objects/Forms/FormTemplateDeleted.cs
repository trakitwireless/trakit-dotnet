using System;

namespace trakit.objects {
	/// <summary>
	/// The full definition of a form that needs to be filled out.
	/// </summary>
	public class FormTemplateDeleted : Subscribable, IIdUlong, IBelongCompany, IDeletable {
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