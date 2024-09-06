namespace trakit.objects {
	/// <summary>
	/// A grouping of credentials, information, preferences, and permissions for a person or machine to login to the system and access its resources.
	/// </summary>
	/// <category>Users and Groups</category>
	/// <override complex="true">
	/// <merge type="Vorgon.UserGeneral" />
	/// <merge type="Vorgon.UserAdvanced" />
	/// </override>
	public class User {
		/// <summary>
		/// General details about this user.
		/// </summary>
		/// <override skip="true" />
		public UserGeneral general;
		/// <summary>
		/// Advanced details about this user.
		/// </summary>
		/// <override skip="true" />
		public UserAdvanced advanced;

		/// <summary>
		/// Unique identifier of this user.
		/// </summary>
		/// <override min-length="6" max-length="254" format="email" readonly="true" />
		public string login => this.general?.login
						?? this.advanced?.login
						?? null;
		/// <summary>
		/// Object version keys used to validate synchronization for all object properties.
		/// </summary>
		/// <override name="v" count="2" readonly="true">
		/// <element key="0">The first element is for the general properties</element>
		/// <element key="1">The second element is for the advanced properties</element>
		/// </override>
		public int[] version => new int[] {
			(int?)this.general?.version[0] ?? -1,
			(int?)this.advanced?.version[0] ?? -1,
		};
	}
}