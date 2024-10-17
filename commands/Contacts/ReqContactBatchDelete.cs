using System.Net.Http;
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

		public override HttpMethod httpVerb => throw new System.NotImplementedException();

		public override string httpRoute => throw new System.NotImplementedException();

		public override string socketCommand => throw new System.NotImplementedException();
	}
}