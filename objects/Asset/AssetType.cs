﻿namespace trakit.objects {
	/// <summary>
	/// The four supported types of trackable things.
	/// </summary>
	public enum AssetType : byte {
		/// <summary>
		/// Generic thing.
		/// </summary>
		asset,
		/// <summary>
		/// Human (or alien) Person.
		/// </summary>
		person,
		/// <summary>
		/// A towed vehicle without an engine.
		/// </summary>
		trailer,
		/// <summary>
		/// A vehicle that moves with its own power.
		/// </summary>
		vehicle,
	}
}