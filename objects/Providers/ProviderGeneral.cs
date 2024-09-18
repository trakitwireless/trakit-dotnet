using System;
using System.Collections.Generic;

namespace trakit.objects {
	/// <summary>
	/// Protocols supported by the system.
	/// </summary>
	public enum ProviderType : byte {
		/// <summary>
		/// Your guess is as good as mine.
		/// It should never be this.
		/// </summary>
		unknown,
		/// <summary>
		/// Sierra Wireless AirLink RAP protocol
		/// </summary>
		[Obsolete("No longer supported")]
		airlink,
		/// <summary>
		/// Sixnet BlueTree BEP protocol
		/// </summary>
		[Obsolete("No longer supported")]
		bluetree,
		/// <summary>
		/// Gen-X modem protocol
		/// </summary>
		genx,
		/// <summary>
		/// CalAmp LMU series protocol
		/// </summary>
		[Obsolete("Use calamp instead")]
		lmu,
		/// <summary>
		/// CalAmp TTU series protocol
		/// </summary>
		[Obsolete("Use calamp instead")]
		ttu,
		/// <summary>
		/// Novotel Enfora SpiderAT protocol
		/// </summary>
		[Obsolete("Use enfora instead")]
		spiderAT,
		/// <summary>
		/// Novotel Enfora SpiderMT protocol
		/// </summary>
		[Obsolete("Use enfora instead")]
		spiderMT,
		/// <summary>
		/// Trak iT Wireless Mobile App
		/// </summary>
		mobile,
		/// <summary>
		/// TachWest DataTrans protocol
		/// </summary>
		datatrans,
		/// <summary>
		/// Xirgo modem protocol
		/// </summary>
		[Obsolete("No longer supported")]
		xirgo,
		/// <summary>
		/// Bell Mobility LBS
		/// </summary>
		lbs,
		/// <summary>
		/// Certified Tracking protocol
		/// </summary>
		[Obsolete("No longer supported")]
		titan,
		/// <summary>
		/// Concox Tracker protocol
		/// </summary>
		[Obsolete("No longer supported")]
		concox,
		/// <summary>
		/// Aspenta Open API format
		/// </summary>
		[Obsolete("No longer supported")]
		aspenta,
		/// <summary>
		/// Fleet Freedom JSON protocol
		/// </summary>
		[Obsolete("No longer supported")]
		json,
		/// <summary>
		/// SmartWitness dashcam formats
		/// </summary>
		smartwitness,
		/// <summary>
		/// CalAmp LMU/TTU modem protocols
		/// </summary>
		calamp,
		/// <summary>
		/// Enfora (Novotel) modem protocols
		/// </summary>
		[Obsolete("No longer supported")]
		enfora,
		/// <summary>
		/// BeWhere beacon protocols
		/// </summary>
		bewhere,
		/// <summary>
		/// ATrack device protocols
		/// </summary>
		atrack,
		/// <summary>
		/// Teltonika device protocols
		/// </summary>
		teltonika,
	}
	/// <summary>
	/// Progress lifetime of changing the on-board information of a remote device.
	/// </summary>
	public enum ProvisioningStatus : byte {
		/// <summary>
		/// The new configuration has been created, but not yet sent to the provider.
		/// </summary>
		created,
		/// <summary>
		/// Your guess is as good as mine.  It should never be this.
		/// </summary>
		unknown,
		/// <summary>
		/// Provider is notified of new configuration, but has not yet checked in.
		/// </summary>
		pending,
		/// <summary>
		/// A message was sent to the provider asking it to check in.
		/// </summary>
		otaSent,
		/// <summary>
		/// Currently sending configuration over-the-air to the provider.
		/// </summary>
		inProgress,
		/// <summary>
		/// Only a partial configuration was sent to the provider.
		/// </summary>
		partial,
		/// <summary>
		/// The maximum number of retries were attempted before giving up.
		/// </summary>
		maxRetries,
		/// <summary>
		/// Something went wrong while trying to send configuration.
		/// </summary>
		error,
		/// <summary>
		/// New configuration successfully sent to provider.
		/// </summary>
		completed,
		/// <summary>
		/// Sending of the new configuration was halted by a user.
		/// </summary>
		cancelled,
	}

	/// <summary>
	/// Device/hardware information and configuration.
	/// </summary>
	public class ProviderGeneral : Subscribable, INamed, IBelongCompany, IDeletable {
		/// <summary>
		/// Unique identifier of this device.
		/// </summary>
		/// <seealso cref="Provider.id" />
		/// <override min-length="10" max-length="50" />
		public string id { get; set; }
		/// <summary>
		/// The company to which this device belongs.
		/// </summary>
		/// <seealso cref="Company.id" />
		public ulong company { get; set; }
		/// <summary>
		/// A nickname given to the device/hardware.
		/// </summary>
		/// <override max-length="100" />
		public string name { get; set; }
		/// <summary>
		/// Notes!
		/// </summary>
		public string notes { get; set; }
		/// <summary>
		/// The kind of communication protocol this device uses.
		/// </summary>
		public ProviderType kind;
		/// <summary>
		/// The asset for which this device provides field data.
		/// </summary>
		/// <seealso cref="Asset.id" />
		public ulong? asset;
		/// <summary>
		/// The provider's current (or pending) configuration profile.
		/// </summary>
		/// <seealso cref="ProviderConfig.id" />
		/// <seealso cref="ProviderConfiguration.id" />
		public ulong configuration;
		/// <summary>
		/// A timestamp from when the provider last checked for a new script or new geofences.
		/// </summary>
		public DateTime? lastCheckIn;
		/// <summary>
		/// A timestamp from when the script status was updated by a <see cref="User"/> or a <see cref="Provider"/>.
		/// </summary>
		public DateTime? scriptLast;
		/// <summary>
		/// A timestamp from when the geofence list was updated by a <see cref="User"/> or a <see cref="Provider"/>.
		/// </summary>
		public DateTime? geofenceLast;

		/// <summary>
		/// The system's progress of updating the device's programming.
		/// </summary>
		public ProvisioningStatus scriptStatus;
		/// <summary>
		/// The system's progress of updating the device's on-board geofence definitions.
		/// </summary>
		public ProvisioningStatus geofenceStatus;
		/// <summary>
		/// The system's progress of updating the device's firmware/application.
		/// </summary>
		public ProvisioningStatus firmwareStatus;
		/// <summary>
		/// The password programmed on the device used to ensure the system is the only client authorized to make changes.
		/// </summary>
		/// <override max-length="50" />
		public string password;
		/// <summary>
		/// The short-name of the kind of PND attached to this device.
		/// Leave blank if none.
		/// </summary>
		/// <override max-length="50" />
		public string pnd;
		/// <summary>
		/// The firmware/application version number.
		/// </summary>
		/// <override max-length="100" />
		public string firmware;
		/// <summary>
		/// The phone number of this device.
		/// </summary>
		/// <override format="phone" />
		public ulong? phoneNumber;
		/// <summary>
		/// A list of read-only values about the device like IMEI, ESN, firmware version, hardware revision, etc...
		/// </summary>
		/// <override>
		/// <keys>
		/// <seealso cref="DataName" />
		/// </keys>
		/// </override>
		public Dictionary<string, string> information;
		/// <summary>
		/// ICCID of the SIM card installed in this provider
		/// </summary>
		public string sim;

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