using trakit.objects;

namespace trakit.commands {
	/// <summary>
	/// 
	/// </summary>
	public class ReqContactBatchDelete : Request {
		/// <summary>
		/// 
		/// </summary>
		public ParamId[] contacts { get; set; }
	}
}