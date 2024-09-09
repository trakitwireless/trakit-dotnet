namespace trakit.objects {
	/// <summary>
	/// Any derived class can/should be serialized and given to a user.
	/// </summary>
	public abstract class Subscribable {
		/// <summary>
		/// Object version keys used to validate synchronization for all object properties.
		/// </summary>
		public uint[] v;
	}
}