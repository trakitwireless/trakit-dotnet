namespace trakit.objects {
	/// <summary>
	/// A container for the details of the <see cref="Machine"/> requested.
	/// </summary>
	public class RespSelfMachine : Machine {
		/// <summary>
		/// The list of <see cref="UserGroup"/> to which this <see cref="User"/> belongs.
		/// </summary>
		new public UserGroup[] groups;
	}
}