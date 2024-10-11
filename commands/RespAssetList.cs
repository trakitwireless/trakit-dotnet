using trakit.objects;

namespace trakit.commands {
	/// <summary>
	/// 
	/// </summary>
	public class RespAssetList : Response {
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