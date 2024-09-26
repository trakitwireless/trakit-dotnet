namespace trakit.objects {
	/// <summary>
	/// A container for the id and owning <see cref="Company.id"/> of the object requested/created.
	/// </summary>
	public class RespListAssetBy : ResponseType {
		/// <summary>
		/// The list of requested <see cref="Asset"/>s.
		/// </summary>
		public Asset[] assets;
	}
}