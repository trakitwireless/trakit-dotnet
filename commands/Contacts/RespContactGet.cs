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
	}
}