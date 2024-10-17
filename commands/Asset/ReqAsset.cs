using trakit.objects;

namespace trakit.commands {
	/// <summary>
	/// A container for the <see cref="asset"/> object.
	/// </summary>
	public class ReqAsset : Request {
		/// <summary>
		/// An object to contain the "id" of the <see cref="Asset"/>.
		/// </summary>
		public ParamId asset { get; set; }
	}
}