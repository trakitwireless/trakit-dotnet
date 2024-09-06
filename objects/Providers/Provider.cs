namespace trakit.objects {
	/// <summary>
	/// A device, modem, or service which provides events from the field.
	/// </summary>
	/// <category>Providers and Configurations</category>
	/// <override complex="true">
	/// <merge type="Vorgon.ProviderGeneral" />
	/// <merge type="Vorgon.ProviderAdvanced" />
	/// <merge type="Vorgon.ProviderControl" />
	/// </override>
	public class Provider {
		/// <summary>
		/// General details about this provider.
		/// </summary>
		/// <override skip="true" />
		public ProviderGeneral general;
		/// <summary>
		/// Advanced details about this provider.
		/// </summary>
		/// <override skip="true" />
		public ProviderAdvanced advanced;
		/// <summary>
		/// Managing and controlling communication with this provider.
		/// </summary>
		public ProviderControl control;

		/// <summary>
		/// Unique identifier of this provider.
		/// </summary>
		/// <override min-length="10" max-length="50" readonly="true" />
		public string id => this.general?.id
						?? this.advanced?.id
						?? this.control?.id
						?? null;
		/// <summary>
		/// Object version keys used to validate synchronization for all object properties.
		/// </summary>
		/// <override name="v" count="3" readonly="true">
		/// <element key="0">The first element is for the general properties</element>
		/// <element key="1">The second element is for the advanced properties</element>
		/// <element key="2">The third element is for the control properties</element>
		/// </override>
		public int[] version => new int[] {
			(int?)this.general?.version[0] ?? -1,
			(int?)this.advanced?.version[0] ?? -1,
			(int?)this.control?.version[0] ?? -1,
		};
	}
}