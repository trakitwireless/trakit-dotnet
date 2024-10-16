using trakit.objects;

namespace trakit.commands {
	/// <summary>
	/// A container for the requested <see cref="providerAdvanceds"/>.
	/// </summary>
	public abstract class RespListProviderAdvanced : Response {
		/// <summary>
		/// The list of requested <see cref="ProviderAdvanced"/>s.
		/// </summary>
		public ProviderAdvanced[] providerAdvanceds;
	}

	/// <summary>
	/// A container owner <see cref="Company"/> of the collection.
	/// </summary>
	public class RespListProviderAdvancedByCompany : RespListProviderAdvanced {
		/// <summary>
		/// Identifier of the <see cref="Company"/> to which this collection belongs.
		/// </summary>
		public RespId company;
	}
	/// <summary>
	/// A container owner <see cref="Company"/> of the collection.
	/// </summary>
	public class RespListProviderAdvancedByConfig: RespListProviderAdvanced {
		/// <summary>
		/// Identifier of the <see cref="ProviderConfig"/> (or <see cref="ProviderConfiguration"/>) to which this collection belongs.
		/// </summary>
		public RespId config;
	}
}