using trakit.objects;

namespace trakit.commands {
	/// <summary>
	/// A container for the <see cref="Provider"/>.
	/// </summary>
	public class RespProviderGet : Response {
		/// <summary>
		/// The requested <see cref="Provider"/>.
		/// </summary>
		public Provider provider;
	}
}