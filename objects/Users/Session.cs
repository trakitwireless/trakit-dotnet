using System;

namespace trakit.objects {
	/// <summary>
	/// Current state of a session
	/// </summary>
	/// <category>Users and Groups</category>
	public enum SessionStatus : byte {
		/// <summary>
		/// Invalid session reference.
		/// </summary>
		notFound,
		/// <summary>
		/// Session created but user hasn't logged-in yet.
		/// </summary>
		created,
		/// <summary>
		/// User is logged-in and one or more WebSocket connections are open.
		/// </summary>
		active,
		/// <summary>
		/// User is logged-in but no WebSocket connections are open.
		/// </summary>
		idle,
		/// <summary>
		/// User is logged-in and password is expired and needs to be changed before any commands can be processed.
		/// </summary>
		passwordExpired,
		/// <summary>
		/// Session is being killed because it has expired.
		/// </summary>
		expired,
	}

	/// <summary>
	/// Information about other users' sessions.
	/// </summary>
	/// <category>Users and Groups</category>
	/// <override skip="true" />
	public class Session {
		/// <summary>
		/// UserAgent identification string
		/// </summary>
		public string userAgent { get; set; }
		/// <summary>
		/// The IP address of the user last used to connect using this session.
		/// </summary>
		/// <override max-length="15" format="ipv4" />
		public string ipAddress { get; set; }
		/// <summary>
		/// The login of the user to which this session belongs.
		/// </summary>
		/// <seealso cref="User.login" />
		public string user { get; set; }
		/// <summary>
		/// Date/time stamp of the last connection using this session.
		/// </summary>
		public DateTime lastActivity { get; set; }
		/// <summary>
		/// Indicates that the password has expired.
		/// </summary>
		public bool passwordExpired { get; set; }

		/// <summary>
		/// Session specific identifier of this user session.
		/// The value changes value from session to session to prevent session hijacking attacks.
		/// </summary>
		public string id { get; set; }
		/// <summary>
		/// Date/time stamp of when this user session was created.
		/// </summary>
		public DateTime created { get; set; }
		/// <summary>
		/// Getter shortcut for the session user's company id.
		/// This property will throw an exception if the itemCollection is null (getter also if company is not set).
		/// </summary>
		public ulong company;
		/// <summary>
		/// A count of the number of connected sockets for this session.
		/// The setter will throw an exception if the itemCollection is null.
		/// </summary>
		public int sockets;
		/// <summary>
		/// The name or route of the last command executed by the client.
		/// </summary>
		public string lastCommand;
		/// <summary>
		/// Date/time stamp of when this user session will be automatically killed.
		/// </summary>
		public DateTime expires { get; set; }
		/// <summary>
		/// Expire timeout (in minutes) from session policy.
		/// </summary>
		public int timeout { get; set; }
	}
}