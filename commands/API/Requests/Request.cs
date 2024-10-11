namespace trakit.commands {
	/// <summary>
	/// Base class for all command parameters.
	/// All command parameter classes use this as the base.
	/// </summary>
	/// <remarks>
	/// This class exists solely to create an inheritance chain.
	/// Child classes should contain members required to execute a command.
	/// </remarks>
	public abstract class Request {
		/// <summary>
		/// Identifier used by external system to correlate requests to responses.
		/// </summary>
		public int? reqId { get; set; }
	}
}