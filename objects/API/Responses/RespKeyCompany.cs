﻿namespace trakit.objects {
	/// <summary>
	/// A container for the <see cref="Machine.key"/> and owning <see cref="Company.id"/> of the <see cref="Machine"/> requested/created.
	/// </summary>
	public class RespKeyCompany : RespKey {
		/// <summary>
		/// Identifier of the <see cref="Company"/> to which the <see cref="Machine"/> belongs.
		/// </summary>
		public ulong company;
	}
}