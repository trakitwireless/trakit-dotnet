using trakit.objects;

namespace trakit.commands {
	/// <summary>
	/// A container for the <see cref="provider"/> object.
	/// </summary>
	public abstract class ReqProvider : Request {
		/// <summary>
		/// An object to contain the "id" of the <see cref="Provider"/>.
		/// </summary>
		public ParamIdentifier provider { get; set; }
	}
}