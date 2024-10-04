using System;
using System.Collections.Generic;

namespace trakit.objects {
	/// <summary>
	/// A grouping of credentials, information, preferences, and permissions for a person or machine to login to the system and access its resources.
	/// </summary>
	public class User : Complexable, IEnabled, IBelongCompany, IHavePreferences, IDeletable {
		/// <summary>
		/// 
		/// </summary>
		protected override Subscribable[] pieces => new Subscribable[] {
			this.general,
			this.advanced,
		};

		/// <summary>
		/// The unique public email address used to access the system.
		/// </summary>
		/// <seealso cref="User.login" />
		/// <override min-length="6" max-length="254" format="email" />
		public string login => this.general?.login
						?? this.advanced?.login
						?? throw new NullReferenceException("general");
		/// <summary>
		/// The company to which this user belongs.
		/// </summary>
		/// <seealso cref="Company.id" />
		public ulong company => this.general?.company
							?? this.advanced?.company
							?? throw new NullReferenceException("general");

		/// <summary>
		/// 
		/// </summary>
		public UserGeneral general { get; set; }
		/// <summary>
		/// Indicated whether the credentials have expired according to the company's policy.
		/// </summary>
		public bool passwordExpired {
			get => this.general?.passwordExpired ?? throw new NullReferenceException("general");
			set => (this.general ?? throw new NullReferenceException("general")).passwordExpired = value;
		}
		/// <summary>
		/// Indicates whether system access is disabled.
		/// </summary>
		public bool enabled {
			get => this.general?.enabled ?? throw new NullReferenceException("general");
			set => (this.general ?? throw new NullReferenceException("general")).enabled = value;
		}
		/// <summary>
		/// Human friendly name for these credentials
		/// </summary>
		/// <override max-length="100" />
		public string nickname {
			get => this.general?.nickname ?? throw new NullReferenceException("general");
			set => (this.general ?? throw new NullReferenceException("general")).nickname = value;
		}
		/// <summary>
		/// Contact information for this user.
		/// </summary>
		/// <seealso cref="Contact.id" />
		public ulong? contact {
			get => this.general?.contact ?? throw new NullReferenceException("general");
			set => (this.general ?? throw new NullReferenceException("general")).contact = value;
		}
		/// <summary>
		/// The user's local timezone.
		/// </summary>
		/// <seealso cref="Timezone.code" />
		/// <override type="System.String" format="codified" />
		public string timezone {
			get => this.general?.timezone ?? throw new NullReferenceException("general");
			set => (this.general ?? throw new NullReferenceException("general")).timezone = value;
		}
		/// <summary>
		/// Preferred region/language for the UI and notifications.
		/// Valid formats use &lt;ISO 639-1&gt;&lt;dash&gt;&lt;ISO 3166-2&gt; such as "fr-CA" or "en-US".
		/// </summary>
		/// <override min-length="2" max-length="5" format="codified" />
		public string language {
			get => this.general?.language ?? throw new NullReferenceException("general");
			set => (this.general ?? throw new NullReferenceException("general")).language = value;
		}
		/// <summary>
		/// The format strings defining the preferred way to display ambiguous values.
		/// </summary>
		/// <override>
		/// <keys format="codified" />
		/// <values max-length="20" format="datetimetemplate" />
		/// </override>
		public Dictionary<string, string> formats {
			get => this.general?.formats ?? throw new NullReferenceException("general");
			set => (this.general ?? throw new NullReferenceException("general")).formats = value;
		}
		/// <summary>
		/// Preferred way of displaying ambiguous numbers in the context of measurements.
		/// </summary>
		/// <override>
		/// <keys format="codified" />
		/// </override>
		public Dictionary<string, SystemsOfUnits> measurements {
			get => this.general?.measurements ?? throw new NullReferenceException("general");
			set => (this.general ?? throw new NullReferenceException("general")).measurements = value;
		}
		/// <summary>
		/// Additional options which do not fit in with the formats or measurements preferences.
		/// </summary>
		/// <override>
		/// <keys format="codified" />
		/// <values max-length="20" />
		/// </override>
		public Dictionary<string, string> options {
			get => this.general?.options ?? throw new NullReferenceException("general");
			set => (this.general ?? throw new NullReferenceException("general")).options = value;
		}
		/// <summary>
		/// Definition of how and when to send alerts to the user.
		/// </summary>
		/// <override max-count="7" />
		public List<UserNotifications> notify {
			get => this.general?.notify ?? throw new NullReferenceException("general");
			set => (this.general ?? throw new NullReferenceException("general")).notify = value;
		}

		/// <summary>
		/// 
		/// </summary>
		public UserAdvanced advanced { get; set; }
		/// <summary>
		/// A list of groups to which this user belongs.
		/// </summary>
		/// <seealso cref="UserGroup.id" />
		public List<ulong> groups {
			get => this.advanced?.groups ?? throw new NullReferenceException("advanced");
			set => (this.advanced ?? throw new NullReferenceException("advanced")).groups = value;
		}
		/// <summary>
		/// Individual permission rules which override the group rules.
		/// </summary>
		public List<Permission> permissions {
			get => this.advanced?.permissions ?? throw new NullReferenceException("advanced");
			set => (this.advanced ?? throw new NullReferenceException("advanced")).permissions = value;
		}

		// IRequestable
		/// <summary>
		/// The <see cref="login"/> is the key.
		/// </summary>
		/// <returns></returns>
		public override string getKey() => this.login;

		// IDeletable
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