using System.Net.Http;
using trakit.objects;

namespace trakit.commands {
	/// <summary>
	/// Gets details of the specified <see cref="Provider"/>.
	/// </summary>
	public class ReqProviderGet : ReqProvider, IReqIDeletable {
		/// <summary>
		/// When true, the command will also return a deleted <see cref="Provider"/> (if it exists).
		/// </summary>
		public bool includeDeleted { get; set; }

		public override HttpMethod httpVerb => throw new System.NotImplementedException();

		public override string httpRoute => throw new System.NotImplementedException();

		public override string socketCommand => throw new System.NotImplementedException();
	}
}