namespace trakit.objects {
	/// <summary>
	/// The priority of the alert.
	/// </summary>
	/// <category>Messaging</category>
	public enum AlertPriority : byte {
		/// <summary>
		/// Sends when no other alerts are pending in the queue.
		/// </summary>
		low,
		/// <summary>
		/// Sends in when there are no high priority alerts in the queue.
		/// </summary>
		normal,
		/// <summary>
		/// Sends before low and normal priority alerts.
		/// </summary>
		high,
	}

	/// <summary>
	/// An automatically generated notification sent to a user by the system.
	/// </summary>
	/// <category>Messaging</category>
	public class AssetAlert : MessageBase {
		/// <summary>
		/// The priority for which this message must send.
		/// </summary>
		public AlertPriority priority;
	}
}