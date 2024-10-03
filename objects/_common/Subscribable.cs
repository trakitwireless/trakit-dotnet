﻿namespace trakit.objects {
	/// <summary>
	/// Any derived class can/should be serialized and given to a user.
	/// </summary>
	public abstract class Subscribable : IRequestable {
		/// <summary>
		/// Object version keys used to validate synchronization for all object properties.
		/// </summary>
		public uint[] v;
		/// <summary>
		/// Returns a string which can be used as a unique identifier for this object.
		/// Strings are unique for each type of object, but can be identical for different object types.
		/// </summary>
		/// <seealso cref="IIdUlong.id"/>
		/// <seealso cref="Machine.key"/>
		/// <seealso cref="Provider.id"/>
		/// <seealso cref="ProviderRegistration.code"/>
		/// <seealso cref="User.login"/>
		/// <seealso cref="UserGeneral.login"/>
		/// <seealso cref="UserAdvanced.login"/>
		/// <returns>A string unique for this type of object.</returns>
		public abstract string getKey();
	}
}