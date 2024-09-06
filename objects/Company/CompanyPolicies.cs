using System.Collections.Generic;

namespace trakit.objects {
	/// <summary>
	/// Defines the behaviour of the system when a user creates multiple sessions.
	/// </summary>
	/// <category>Companies</category>
	/// <override name="SessionMultiUser" />
	public enum MultiUserPolicy : byte {
		/// <summary>
		/// Allow users to create multiple simultaneous sessions.
		/// </summary>
		allow,
		/// <summary>
		/// Deny users from creating new sessions if they already have an active session.
		/// </summary>
		deny,
		/// <summary>
		/// Allow users to create a new session, but automatically kill the previous session.
		/// </summary>
		replace,
	}
	/// <summary>
	/// Defines how User passwords expire.
	/// </summary>
	/// <category>Companies</category>
	/// <override name="PasswordExpiryMode" />
	public enum ExpiryModePolicy : byte {
		/// <summary>
		/// Passwords never expire.
		/// </summary>
		never,
		/// <summary>
		/// Passwords expire after a defined number of days.
		/// </summary>
		days,
		/// <summary>
		/// Passwords expire after a defined number of successful logins.
		/// </summary>
		sessions,
	}

	/// <summary>
	/// The password and session lifetime policies for this Company.
	/// </summary>
	/// <category>Companies</category>
	public class CompanyPolicies : Subscribable, IIdUlong, IAmCompany {
		/// <summary>
		/// Unique identifier of the Company.
		/// </summary>
		/// <seealso cref="Company.id" />
		public ulong id { get; set; }
		/// <summary>
		/// The unique identifier of this company's parent organization.
		/// </summary>
		/// <seealso cref="Company.id" />
		public ulong parent { get; set; }
		/// <summary>
		/// The session lifetime policy.
		/// </summary>
		public SessionPolicy sessionPolicy;
		/// <summary>
		/// The password complexity and expiry policy.
		/// </summary>
		public PasswordPolicy passwordPolicy;
	}

	/// <summary>
	/// The password complexity and expiry policy.
	/// </summary>
	/// <category>Companies</category>
	public class PasswordPolicy {
		/// <summary>
		/// The minimum number of characters required.
		/// </summary>
		public byte minimumLength;
		/// <summary>
		/// Do passwords require alphabetical characters.
		/// </summary>
		public bool includeLetters;
		/// <summary>
		/// Do passwords require numeric characters.
		/// </summary>
		public bool includeNumbers;
		/// <summary>
		/// Do passwords require upper-case and lower-case letters.
		/// </summary>
		public bool includeUpperLower;
		/// <summary>
		/// Do passwords require non-alphanumeric characters.
		/// </summary>
		public bool includeSpecial;
		/// <summary>
		/// Defines how passwords expire.
		/// </summary>
		public ExpiryModePolicy expireMode;
		/// <summary>
		/// The threshold for expiry.
		/// </summary>
		public byte expireThreshold;  // days
	}
	/// <summary>
	/// The session lifetime policy.
	/// </summary>
	/// <category>Companies</category>
	public class SessionPolicy {
		/// <summary>
		/// The list of applications users are allowed to use to create sessions.
		/// </summary>
		public List<string> applications;
		/// <summary>
		/// Restrict session creation to only the provided IPv4 ranges (using CIDR slash-notation).  Leave blank for Internet access.
		/// </summary>
		/// <override>
		/// <values max-length="19" format="ipv4" />
		/// </override>
		public List<string> ipv4Ranges;
		/// <summary>
		/// Defines the behaviour of the system when a user creates multiple sessions.
		/// </summary>
		public MultiUserPolicy multiUser;
		/// <summary>
		/// Defines whether a session should be automatically killed when the connection breaks.
		/// </summary>
		public bool idleAllowed;
		/// <summary>
		/// The lifetime duration of a session in minutes.
		/// </summary>
		public ushort expireTimeout;
		/// <summary>
		/// The maximum number of sessions allowed per user.
		/// </summary>
		public byte maxSessions;
	}
}