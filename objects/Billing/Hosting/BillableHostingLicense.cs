namespace trakit.objects {
	/// <summary>
	/// The kind of license being billed.
	/// </summary>
	public enum BillableLicenseType : byte {
		/// <summary>
		/// SmartWitness data hosting fee
		/// </summary>
		/// <seealso cref="ProviderType.smartwitness" />
		smartwitness,
		/// <summary>
		/// BeWhere license fee
		/// </summary>
		/// <seealso cref="ProviderType.bewhere" />
		bewhere,
		/// <summary>
		/// CalAmp PULS fee
		/// </summary>
		/// <seealso cref="ProviderType.calamp" />
		calamp,
	}

	/// <summary>
	/// A hardware license for providers
	/// </summary>
	public class BillableHostingLicense : BillableHostingBase {
		/// <summary>
		/// The type of hardware license
		/// </summary>
		public BillableLicenseType kind;
	}
}