using trakit.objects;

namespace trakit.commands {
	/// <summary>
	/// Gets details of the specified <see cref="Asset"/>.
	/// </summary>
	public class ReqAsset : Request {
		/// <summary>
		/// An object to contain the "id" of the <see cref="Asset"/>.
		/// </summary>
		public ParamId asset { get; set; }
		/// <summary>
		/// When true, the command will also return a deleted <see cref="Asset"/> (if it exists).
		/// </summary>
		public bool includeDeleted;
	}
}