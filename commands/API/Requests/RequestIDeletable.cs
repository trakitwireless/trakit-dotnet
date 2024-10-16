namespace trakit.commands {
	/// <summary>
	/// Base class for all command parameters.
	/// All command parameter classes use this as the base.
	/// </summary>
	/// <remarks>
	/// This class exists solely to create an inheritance chain.
	/// Child classes should contain members required to execute a command.
	/// </remarks>
	public abstract class RequestIDeletable : Request {
		/// <summary>
		/// When true, the command will also return a deleted objects (if it exists).
		/// </summary>
		public bool includeDeleted;
	}
}