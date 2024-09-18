﻿using System;
using System.Collections.Generic;

namespace trakit.objects {
	/// <summary>
	/// A grouping of credentials, information, preferences, and permissions for a person or machine to login to the system and access its resources.
	/// </summary>
	public class User : Subscribable, IEnabled, IBelongCompany, IHavePreferences, IDeletable {
		/// <summary>
		/// The unique public email address used to access the system.
		/// </summary>
		/// <seealso cref="User.login" />
		/// <override min-length="6" max-length="254" format="email" />
		public string login { get; set; }
		/// <summary>
		/// The company to which this user belongs.
		/// </summary>
		/// <seealso cref="Company.id" />
		public ulong company { get; set; }
		/// <summary>
		/// Indicated whether the credentials have expired according to the company's policy.
		/// </summary>
		public bool passwordExpired;
		/// <summary>
		/// Indicates whether system access is disabled.
		/// </summary>
		public bool enabled { get; set; }
		/// <summary>
		/// Human friendly name for these credentials
		/// </summary>
		/// <override max-length="100" />
		public string nickname;
		/// <summary>
		/// Contact information for this user.
		/// </summary>
		/// <seealso cref="Contact.id" />
		public ulong? contact;
		/// <summary>
		/// The user's local timezone.
		/// </summary>
		/// <seealso cref="Timezone.code" />
		/// <override type="System.String" format="codified" />
		public string timezone { get; set; }
		/// <summary>
		/// Preferred region/language for the UI and notifications.
		/// Valid formats use &lt;ISO 639-1&gt;&lt;dash&gt;&lt;ISO 3166-2&gt; such as "fr-CA" or "en-US".
		/// </summary>
		/// <override min-length="2" max-length="5" format="codified" />
		public string language { get; set; }
		/// <summary>
		/// The format strings defining the preferred way to display ambiguous values.
		/// </summary>
		/// <override>
		/// <keys format="codified" />
		/// <values max-length="20" format="datetimetemplate" />
		/// </override>
		public Dictionary<string, string> formats { get; set; }
		/// <summary>
		/// Preferred way of displaying ambiguous numbers in the context of measurements.
		/// </summary>
		/// <override>
		/// <keys format="codified" />
		/// </override>
		public Dictionary<string, SystemsOfUnits> measurements { get; set; }
		/// <summary>
		/// Additional options which do not fit in with the formats or measurements preferences.
		/// </summary>
		/// <override>
		/// <keys format="codified" />
		/// <values max-length="20" />
		/// </override>
		public Dictionary<string, string> options { get; set; }
		/// <summary>
		/// Definition of how and when to send alerts to the user.
		/// </summary>
		/// <override max-count="7" />
		public List<UserNotifications> notify;

		/// <summary>
		/// A list of groups to which this user belongs.
		/// </summary>
		/// <seealso cref="UserGroup.id" />
		public List<ulong> groups { get; set; }
		/// <summary>
		/// Individual permission rules which override the group rules.
		/// </summary>
		public List<Permission> permissions { get; set; }

		/// <summary>
		/// Indicates whether this object was deleted.
		/// </summary>
		public bool? deleted { get; set; }
		/// <summary>
		/// Timestamp from the action that deleted or suspended this object.
		/// </summary>
		public DateTime? since { get; set; }
	}
}