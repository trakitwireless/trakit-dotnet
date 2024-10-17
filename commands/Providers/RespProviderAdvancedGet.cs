using trakit.objects;

namespace trakit.commands {
	/// <summary>
	/// A container for the <see cref="providerAdvanced"/>.
	/// </summary>
	public class RespProviderAdvancedGet : Response {
		/// <summary>
		/// The requested <see cref="ProviderAdvanced"/>.
		/// </summary>
		public ProviderAdvanced providerAdvanced;
	}
}