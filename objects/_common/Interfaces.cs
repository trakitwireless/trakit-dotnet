using System;
using System.Collections.Generic;

namespace trakit.objects {
	/// <summary>
	/// An interface for objects with a ulong "id".
	/// </summary>
	/// <category>API Definitions</category>
	public interface IIdUlong {
		/// <summary>
		/// Unique identifier of this object.
		/// </summary>
		ulong id { get; }
	}
	/// <summary>
	/// An interface for objects that can be marked as "deleted".
	/// "Deleted" objects can be restored, but are otherwise treated as "not there".
	/// </summary>
	/// <category>API Definitions</category>
	public interface IDeletable {
		/// <summary>
		/// Marked as true for objects that have been deleted.
		/// </summary>
		bool deleted { get; }
	}
	/// <summary>
	/// An interface for objects that can be marked as "enabled".
	/// "Enabled" objects remain in the system, but are inactive.
	/// </summary>
	/// <category>API Definitions</category>
	public interface IEnabled {
		/// <summary>
		/// Marked as true for objects that have been deleted.
		/// </summary>
		bool enabled { get; }
	}
	/// <summary>
	/// An interface for objects that can be marked as "suspended".
	/// "Suspended" objects can be "revived", but are otherwise treated as "achived" or "inert" (events are not processed).
	/// </summary>
	/// <category>API Definitions</category>
	public interface ISuspendable {
		/// <summary>
		/// Marked as true for objects that have been suspended.
		/// </summary>
		bool suspended { get; }
		/// <summary>
		/// A timestamp from when the object was most recently suspended or revived.
		/// </summary>
		DateTime suspendedUtc { get; }
	}
	/// <summary>
	/// An interface for objects that can be marked as "global".
	/// "Global" objects can be listed in child companies.
	/// </summary>
	/// <category>API Definitions</category>
	public interface IGlobal : IBelongCompany {
		/// <summary>
		/// Indicates whether this icon is available to child companies.
		/// </summary>
		bool global { get; }
	}

	/// <summary>
	/// An interface for objects that have a "name" and "notes".
	/// </summary>
	public interface INamed {
		/// <summary>
		/// This thing's name.
		/// </summary>
		string name { get; }
		/// <summary>
		/// This thing's notes.
		/// </summary>
		string notes { get; }
	}
	/// <summary>
	/// An interface for objcts that have an "icon".
	/// </summary>
	public interface IIconic {
		/// <summary>
		/// This thing's <see cref="Icon.id"/>.
		/// </summary>
		ulong icon { get; }
	}
	/// <summary>
	/// An interface for objects that have "labels".
	/// </summary>
	/// <category>API Definitions</category>
	/// <seealso cref="CompanyStyles.labels" />
	public interface ILabelled {
		/// <summary>
		/// A list of codified labels for this asset or place.
		/// </summary>
		List<string> labels { get; }
	}
	/// <summary>
	/// An interface for objects that have "pictures".
	/// </summary>
	/// <category>API Definitions</category>
	/// <seealso cref="Picture.id" />
	public interface IPictured {
		/// <summary>
		/// A list of picture identifiers of this object.
		/// </summary>
		List<ulong> pictures { get; }
	}
	/// <summary>
	/// An interface for objects that make them more easily visually identifiable.
	/// </summary>
	/// <category>API Definitions</category>
	public interface IVisual {
		/// <summary>
		/// The background colour of the graphic.
		/// </summary>
		/// <override max-length="22" format="colour" />
		string fill { get; }
		/// <summary>
		/// Outline and graphic colour.
		/// </summary>
		/// <override max-length="22" format="colour" />
		string stroke { get; }
		/// <summary>
		/// The name of the symbol for this object.
		/// </summary>
		/// <override max-length="22" format="codified" />
		string graphic { get; }
	}
	/// <summary>
	/// An interface for an object's size on a disk.
	/// </summary>
	/// <category>API Definitions</category>
	public interface IFileSize {
		/// <summary>
		/// Size (in bytes) of the object on the HDD or SSD.
		/// </summary>
		ulong bytes { get; }
	}

	/// <summary>
	/// An interface for all the Company___ classes.
	/// </summary>
	/// <category>Companies</category>
	public interface IAmCompany : IIdUlong {
		/// <summary>
		/// The <see cref="Company"/> to which this <see cref="Company"/> belongs.
		/// </summary>
		ulong parent { get; set; }
	}
	/// <summary>
	/// An interface for objects that belong to a single company.
	/// </summary>
	/// <category>Companies</category>
	public interface IBelongCompany {
		/// <summary>
		/// The <see cref="Company"/> to which this object belongs.
		/// </summary>
		ulong company { get; }
	}
	/// <summary>
	/// An interface for objects that belong to a single asset.
	/// </summary>
	/// <category>Assets</category>
	public interface IBelongAsset {
		/// <summary>
		/// The <see cref="Asset"/> to which this object belongs.
		/// </summary>
		ulong asset { get; }
	}
	/// <summary>
	/// An interface for objects that belong to a single billing profile.
	/// </summary>
	/// <category>Billing</category>
	public interface IBelongBillingProfile {
		/// <summary>
		/// The <see cref="BillingProfile"/> to which this object belongs.
		/// </summary>
		ulong profile { get; }
	}
	/// <summary>
	/// This interface exists so that I can work with Machine and UserAdvanced objects the same way.
	/// </summary>
	/// <category>Users and Groups</category>
	public interface IHavePermissions {
		/// <summary>
		/// A list of groups to which this object.
		/// </summary>
		/// <seealso cref="UserGroup.id" />
		List<ulong> groups { get; }
		/// <summary>
		/// Permission rules which override the group rules.
		/// </summary>
		List<Permission> permissions { get; }
	}
	/// <summary>
	/// This interface exists so that I can work with Machine and UserGeneral objects the same way.
	/// </summary>
	/// <category>Users and Groups</category>
	public interface IHavePreferences {
		/// <summary>
		/// The local timezone for this object.
		/// </summary>
		/// <seealso cref="Timezone.code" />
		string timezone { get; }
		/// <summary>
		/// Preferred region/language for the UI and notifications.
		/// Valid formats use &lt;ISO 639-1&gt;&lt;dash&gt;&lt;ISO 3166-2&gt; such as "fr-CA" or "en-US".
		/// </summary>
		/// <override min-length="2" max-length="5" format="codified" />
		string language { get; }
		/// <summary>
		/// The format strings defining the preferred way to display ambiguous values.
		/// </summary>
		/// <override>
		/// <keys format="codified" />
		/// <values max-length="20" />
		/// </override>
		Dictionary<string, string> formats { get; }
		/// <summary>
		/// Preferred way of displaying ambiguous numbers in the context of measurements.
		/// </summary>
		/// <override>
		/// <keys format="codified" />
		/// </override>
		Dictionary<string, SystemsOfUnits> measurements { get; }
		/// <summary>
		/// Additional options which do not fit in with the formats or measurements preferences.
		/// </summary>
		/// <override>
		/// <keys format="codified" />
		/// <values max-length="20" />
		/// </override>
		Dictionary<string, string> options { get; }
	}

	/// <summary>
	/// For auditable objects, a record of who and what mad the changes.
	/// </summary>
	public interface IAuditable {
		/// <summary>
		/// This class used in conjunction with the <see cref="version"/> member help with synchronization.
		/// </summary>
		public sealed class Updated {
			/// <summary>
			/// The <see cref="User.login"/> or <see cref="Machine.key"/> when the object is updated,
			/// or <see cref="Service.UserAgent"/> if a service updates the object itself.
			/// </summary>
			/// <seealso cref="User.login" />
			public string by;
			/// <summary>
			/// A <see cref="Service.UserAgent"/> that handled the update.
			/// </summary>
			public string from;
			/// <summary>
			/// Timestamp from when the change was made.
			/// </summary>
			public DateTime dts;
		}

		/// <summary>
		/// Details about the change to an object.
		/// </summary>
		public Updated? updated { get; }
		/// <summary>
		/// When the was change procesed.
		/// </summary>
		public DateTime? processedUtc { get; }
	}
}