using System.Collections.Generic;
using System;
using System.Net;

namespace trakit.objects {
	/// <summary>
	/// A device, modem, or service which provides events from the field.
	/// </summary>
	public class Provider : Subscribable, INamed, IBelongCompany {
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
		/// The last IP address of the device.
		/// </summary>
		/// <override type="System.String" format="ipv4" />
		public IPEndPoint lastIP;
		/// <summary>
		/// Often changing values like latitude, longitude, speed, wiring state, VBus information, etc...
		/// </summary>
		/// <override>
		/// <keys>
		/// <seealso cref="GroupName" />
		/// </keys>
		/// <values>
		/// <keys>
		/// <seealso cref="DataName" />
		/// </keys>
		/// </values>
		/// </override>
		public Dictionary<string, Dictionary<string, ProviderData>> attributes;
		/// <summary>
		/// Store-and-forward information like last sequence number of SnF window
		/// </summary>
		public Dictionary<string, string> snf;

		public class Control {
			/// <summary>
			/// Collection of commands for this provider.
			/// </summary>
			public Dictionary<ProviderCommandType, ProviderCommand> commands;
		}
		/// <summary>
		/// Managing communication with Device/hardware.
		/// </summary>
		public Control control;
	}
}