using trakit.objects;

namespace trakit.commands {
	/// <summary>
	/// A container for the <see cref="asset"/>.
	/// </summary>
	public class RespAssetGet : Response {
		/// <summary>
		/// The requested <see cref="Asset"/>.
		/// </summary>
		public Asset asset;
	}
}