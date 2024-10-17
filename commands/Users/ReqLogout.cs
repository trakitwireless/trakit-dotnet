using System.Net.Http;
using trakit.objects;

namespace trakit.commands {
	/// <summary>
	/// 
	/// </summary>
	public class ReqLogout : Request {

		public override HttpMethod httpVerb => HttpMethod.Post;

		public override string httpRoute => "self/logout";

		public override string socketCommand => "logout";
	}
}