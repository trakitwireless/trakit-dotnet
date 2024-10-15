using trakit.objects;

namespace trakit.commands {
	/// <summary>
	/// A container for the <see cref="assetDispatch"/>.
	/// </summary>
	public class RespGetAssetDispatch : Response {
		/// <summary>
		/// The requested <see cref="AssetDispatch"/>.
		/// </summary>
		public AssetDispatch assetDispatch;
	}
}