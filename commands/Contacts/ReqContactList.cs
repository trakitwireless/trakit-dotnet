using System.Net.Http;
using trakit.objects;

namespace trakit.commands {
	/// <summary>
	/// Gets details of the specified <see cref="contact"/>.
	/// </summary>
	public class ReqContactList : Request {
		/// <summary>
		/// Identifier of the <see cref="Company"/> to which this collection belongs.
		/// </summary>
		public ParamId company { get; set; }
		/// <summary>
		/// When true, the command will also return  deleted <see cref="Contact"/>s.
		/// </summary>
		public bool includeDeleted;
	}
}