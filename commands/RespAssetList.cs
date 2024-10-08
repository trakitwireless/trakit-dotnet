using trakit.objects;

namespace trakit.commands {
	/// <summary>
	/// 
	/// </summary>
	public class RespAssetList : ResponseType {
		/// <summary>
		/// 
		/// </summary>
		public RespId company;
		/// <summary>
		/// 
		/// </summary>
		public Asset[] assets;
	}
}