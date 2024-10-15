using trakit.objects;

namespace trakit.commands {
	/// <summary>
	/// A container for the <see cref="assetGeneral"/>.
	/// </summary>
	public class RespGetAssetGeneral : Response {
		/// <summary>
		/// The requested <see cref="Asset"/>.
		/// </summary>
		public AssetGeneral assetGeneral;
	}
}