using trakit.objects;

namespace trakit.commands {
	/// <summary>
	/// A container for the <see cref="contact"/>.
	/// </summary>
	public class RespContactGet : Response {
		/// <summary>
		/// The requested <see cref="Contact"/>.
		/// </summary>
		public Contact contact;
	}
}