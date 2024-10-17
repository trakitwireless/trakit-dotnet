using System.Net.Http;
using trakit.objects;

namespace trakit.commands {
	/// <summary>
	/// A container for the <see cref="contact"/>.
	/// </summary>
	public class RespContactGet : ReqContact {
		/// <summary>
		/// When true, the command will also return a deleted objects (if it exists).
		/// </summary>
		public bool includeDeleted;

		public override HttpMethod httpVerb => throw new System.NotImplementedException();

		public override string httpRoute => throw new System.NotImplementedException();

		public override string socketCommand => throw new System.NotImplementedException();
	}
}