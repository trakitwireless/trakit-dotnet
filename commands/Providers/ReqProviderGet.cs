using trakit.objects;

namespace trakit.commands {
	/// <summary>
	/// Gets details of the specified <see cref="Provider"/>.
	/// </summary>
	public class ReqProviderGet : RequestIDeletable {
		/// <summary>
		/// An object to contain the "id" of the <see cref="Provider"/>.
		/// </summary>
		public ParamIdentifier provider { get; set; }
	}
}