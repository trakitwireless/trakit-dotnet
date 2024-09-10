using System;

namespace trakit.objects {
	/// <summary>
	/// Memos have a lifetime and each status represents a memos's progress through it's life.
	/// </summary>
	/// <category>Messaging</category>
	public enum MessageStatus : byte {
		/// <summary>
		/// Waiting to be sent.
		/// </summary>
		created,
		/// <summary>
		/// Sent or received.
		/// </summary>
		processed,
		/// <summary>
		/// Failed to send.
		/// </summary>
		failed,
		/// <summary>
		/// Failed to send because too many memos were sent.
		/// </summary>
		throttled,
		/// <summary>
		/// Memo sent, but returned with error from receiving server.
		/// </summary>
		bounceback,
		/// <summary>
		/// Memo has been responded to or acknowledged by the recipient.
		/// </summary>
		acknowledged,
	}
	/// <summary>
	/// The kind of protocol used for this memo.
	/// </summary>
	/// <category>Messaging</category>
	public enum MessageType : byte {
		/// <summary>
		/// If the type of memo has not yet been determined, or there was an error determining its type.
		/// </summary>
		unknown,
		/// <summary>
		/// Short Message Service (text message)
		/// </summary>
		sms,
		/// <summary>
		/// Email
		/// </summary>
		email,
		/// <summary>
		/// Garmin/Magellan/etc (Personal Navigation Device)
		/// </summary>
		pnd,
		/// <summary>
		/// Google Cloud Message
		/// </summary>
		gcm,
		/// <summary>
		/// Apple Push Notification Service
		/// </summary>
		apn,
		/// <summary>
		/// WebSocket alert message
		/// </summary>
		socket,
	}

	/// <summary>
	/// A base class for Alerts and Messages.
	/// </summary>
	/// <category>Messaging</category>
	public abstract class MessageBase : Subscribable, IIdUlong, IBelongCompany, IBelongAsset {
		/// <summary>
		/// Unique identifier of this memo.
		/// </summary>
		public ulong id { get; set; }
		/// <summary>
		/// The company to which this memo belongs.
		/// </summary>
		/// <seealso cref="Company.id" />
		public ulong company { get; set; }
		/// <summary>
		/// Lifetime status
		/// </summary>
		public MessageStatus status;
		/// <summary>
		/// Protocol type
		/// </summary>
		public MessageType kind { get; set; }
		/// <summary>
		/// Recipient address
		/// </summary>
		/// <override min-length="6" max-length="254" />
		public string to;
		/// <summary>
		/// Sender address
		/// </summary>
		/// <override min-length="6" max-length="254" />
		public string from;
		/// <summary>
		/// The main contents of the memo.
		/// </summary>
		public string body;
		/// <summary>
		/// Date/time stamp of when the memo was processed.
		/// </summary>
		public DateTime? processed;
		/// <summary>
		/// Date/time stamp of when the memo was delivered (or sent if delivery information unavailable).
		/// </summary>
		public DateTime? delivered;

		/// <summary>
		/// The subject of this message.
		/// </summary>
		/// <override max-length="100" />
		public string subject;
		/// <summary>
		/// The asset to which this message relates.
		/// </summary>
		/// <seealso cref="Asset.id" />
		public ulong asset { get; set; }
		/// <summary>
		/// The user who sent/received this message.
		/// </summary>
		/// <seealso cref="User.login" />
		/// <override max-length="254" format="email" />
		public string user { get; set; }
	}
}