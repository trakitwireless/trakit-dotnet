using trakit.objects;

namespace trakit.commands {
	/// <summary>
	/// A container for the <see cref="contact"/>.
	/// </summary>
	public class RespContactBatchDeleted : Response {
		/// <summary>
		/// Details about deleting/restoring the requested <see cref="Contact"/>.
		/// </summary>
		public RespDeleted[] contacts;
	}
}