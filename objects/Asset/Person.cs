namespace trakit.objects {
	/// <summary>
	/// The full details of a Person, containing all the properties from the <see cref="PersonGeneral"/> and <see cref="AssetAdvanced"/> objects.
	/// </summary>
	public class Person : Asset {
		/// <summary>
		/// A reference to their Company's Contact information.
		/// </summary>
		/// <seealso cref="Contact.id" />
		public ulong contact;
	}
}