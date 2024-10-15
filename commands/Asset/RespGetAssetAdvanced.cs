using trakit.objects;

namespace trakit.commands {
	/// <summary>
	/// A container for the <see cref="assetAdvanced"/>.
	/// </summary>
	public class RespGetAssetAdvanced : Response {
		/// <summary>
		/// The requested <see cref="AssetAdvanced"/>.
		/// </summary>
		public AssetAdvanced assetAdvanced;
	}
}