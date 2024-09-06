namespace trakit.objects {
	/// <summary>
	/// The name of folder where the message is stored.
	/// </summary>
	/// <category>Messaging</category>
	public enum MessageFolder : byte {
		/// <summary>
		/// The inbox is loaded quickly from memory, but messages regularly move to the archive.
		/// </summary>
		inbox,
		/// <summary>
		/// The archive contains all previous messages, but must be queried from disk for retrieval.
		/// </summary>
		archive,
	}

	/// <summary>
	/// A conversational message between users and assets.
	/// </summary>
	/// <category>Messaging</category>
	public class AssetMessage : MessageBase {
		/// <summary>
		/// The folder under which this message is stored.
		/// </summary>
		public MessageFolder folder;
		/// <summary>
		/// Indicates that this is a received message instead of a sent message.
		/// </summary>
		public bool incoming;
		/// <summary>
		/// The user that read this message.  This field is blank/null when unread.
		/// </summary>
		/// <seealso cref="User.login" />
		/// <override max-length="254" format="email" />
		public string readBy;
	}
}