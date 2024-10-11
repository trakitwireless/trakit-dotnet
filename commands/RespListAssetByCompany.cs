﻿namespace trakit.commands {
	/// <summary>
	/// A container for the id and owning <see cref="Company.id"/> of the object requested/created.
	/// </summary>
	public class RespListAssetByCompany : RespListAssetBy {
		/// <summary>
		/// Identifier of the <see cref="Company"/> to which this object belongs.
		/// </summary>
		public ulong company;
	}
}