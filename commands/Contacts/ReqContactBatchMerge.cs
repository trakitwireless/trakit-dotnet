namespace trakit.commands {
	/// <summary>
	/// 
	/// </summary>
	public class ReqContactBatchMerge : Request {
		/// <summary>
		/// 
		/// </summary>
		public ReqContactMerge.Content[] contacts { get; set; }
	}
}