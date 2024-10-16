using trakit.objects;

namespace trakit.commands {
	/// <summary>
	/// A container for the requested <see cref="providers"/>.
	/// </summary>
	public abstract class RespListProvider : Response {
		/// <summary>
		/// The list of requested <see cref="Provider"/>s.
		/// </summary>
		public Provider[] providers;
	}

	/// <summary>
	/// Contains the <see cref="Company.id"/> of the collection.
	/// </summary>
	public class RespListProviderByCompany : RespListProvider {
		/// <summary>
		/// Identifier of the <see cref="Company"/> to which this collection belongs.
		/// </summary>
		public RespId company;
	}
	/// <summary>
	/// A container owner <see cref="Company"/> of the collection.
	/// </summary>
	public class RespListProviderByConfig : RespListProvider {
		/// <summary>
		/// Identifier of the <see cref="ProviderConfig"/> (or <see cref="ProviderConfiguration"/>) to which this collection belongs.
		/// </summary>
		public RespId config;
	}
}