﻿namespace trakit.commands {
	/// <summary>
	/// A container for the <see cref="User"/> login and owning <see cref="Company.id"/> of the user requested/created.
	/// </summary>
	public class RespLoginCompany : RespLogin {
		/// <summary>
		/// Identifier of the <see cref="Company"/> to which the <see cref="User"/> belongs.
		/// </summary>
		public ulong company;
	}
}