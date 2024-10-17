using trakit.objects;

namespace trakit.commands {
	/// <summary>
	/// Gets details of the specified <see cref="Asset"/>.
	/// </summary>
	public class ReqAssetGet : RequestIDeletable {
		/// <summary>
		/// An object to contain the "id" of the <see cref="Asset"/>.
		/// </summary>
		public ParamId asset { get; set; }
	}
}