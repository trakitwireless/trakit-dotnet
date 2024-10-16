using trakit.objects;

namespace trakit.commands {
	/// <summary>
	/// A container for the requested <see cref="providerGenerals"/>.
	/// </summary>
	public abstract class RespListProviderGeneral : Response {
		/// <summary>
		/// The list of requested <see cref="ProviderGeneral"/>s.
		/// </summary>
		public ProviderGeneral[] providerGenerals;
	}

	/// <summary>
	/// A container owner <see cref="Company"/> of the collection.
	/// </summary>
	public class RespListProviderGeneralByCompany : RespListProviderGeneral {
		/// <summary>
		/// Identifier of the <see cref="Company"/> to which this collection belongs.
		/// </summary>
		public RespId company;
	}
	/// <summary>
	/// A container owner <see cref="Company"/> of the collection.
	/// </summary>
	public class RespListProviderGeneralByConfig : RespListProviderGeneral {
		/// <summary>
		/// Identifier of the <see cref="ProviderConfig"/> (or <see cref="ProviderConfiguration"/>) to which this collection belongs.
		/// </summary>
		public RespId config;
	}
}