namespace trakit.objects {
	/// <summary>
	/// The main interface for an object in the Trak-iT system.
	/// </summary>
	public interface IRequestable {
		/// <summary>
		/// Returns a unique identifier as a string.
		/// </summary>
		/// <returns></returns>
		string getKey();
	}
}