﻿namespace trakit.commands {
	/// <summary>
	/// A container for the id and owning <see cref="Company.id"/> of the <see cref="Provider"/> requested/created.
	/// </summary>
	public class RespIdendifierCompany : RespIdendifier {
		/// <summary>
		/// Identifier of the <see cref="Company"/> to which this object belongs.
		/// </summary>
		public ulong company;
	}
}