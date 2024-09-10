using System;
using System.Collections.Generic;

namespace trakit.objects {
	/// <summary>
	/// The kind of command for the device/modem.
	/// </summary>
	public enum ProviderCommandType : byte {
		/// <summary>
		/// If the type of command has not yet been determined, or there was an error determining its type.
		/// </summary>
		unknown,
		/// <summary>
		/// Configuration
		/// </summary>
		config,
		/// <summary>
		/// Geofence
		/// </summary>
		geofence,
		/// <summary>
		/// Dispatch Job
		/// </summary>
		dispatch,
		/// <summary>
		/// GPS report
		/// </summary>
		gps,
		/// <summary>
		/// Status report
		/// </summary>
		status,
		/// <summary>
		/// Control output wire
		/// </summary>
		output,
		/// <summary>
		/// Custom (modem specific) message
		/// </summary>
		custom,
	}
	/// <summary>
	/// Progress lifetime of command for the device/modem.
	/// </summary>
	public enum ProviderCommandStatus : byte {
		/// <summary>
		/// The new command has been created, but not yet sent to the provider.
		/// </summary>
		created,
		/// <summary>
		/// Command was processed and sent to the provider.
		/// </summary>
		pending,
		/// <summary>
		/// Provider is taking some action related to this command. eg. Checking in for config update or getting tasks list.
		/// </summary>
		inProgress,
		/// <summary>
		/// Command was successfully processed by the provider.
		/// </summary>
		completed,
		/// <summary>
		/// Something went wrong while trying to send or process the command.
		/// </summary>
		failed,
		/// <summary>
		/// Sending of the new command was halted by a user.
		/// </summary>
		cancelled,
	}

	/// <summary>
	/// Details regarding a provider command
	/// </summary>
	public class ProviderCommand {
		/// <summary>
		/// Current status of this command.
		/// </summary>
		public ProviderCommandStatus status;
		/// <summary>
		/// Command message body.
		/// </summary>
		public List<string> parameters;
		/// <summary>
		/// Date/time stamp of when the command was created.
		/// </summary>
		public DateTime created;
		/// <summary>
		/// Date/time stamp of when the command was processed.
		/// </summary>
		public DateTime? processed;
	}

	/// <summary>
	/// Managing communication with Device/hardware.
	/// </summary>
	public class ProviderControl : Subscribable, IBelongCompany {
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
		/// Collection of commands for this provider.
		/// </summary>
		public Dictionary<ProviderCommandType, ProviderCommand> commands;
	}
}