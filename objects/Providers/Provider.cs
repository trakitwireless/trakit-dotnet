using System.Collections.Generic;
using System;
using System.Net;

namespace trakit.objects {
	/// <summary>
	/// A device, modem, or service which provides events from the field.
	/// </summary>
	public class Provider : Subscribable, INamed, IBelongCompany, IDeletable {
		/// <summary>
		/// Unique identifier of this device.
		/// </summary>
		/// <seealso cref="Asset.id" />
		public string id => this.general?.id
						?? this.advanced?.id
						?? this.control?.id
						?? throw new NullReferenceException("general");
		/// <summary>
		/// The company to which this device belongs.
		/// </summary>
		/// <seealso cref="Company.id" />
		public ulong company => this.general?.company
							?? this.advanced?.company
							?? this.control?.company
							?? throw new NullReferenceException("general");
		/// <summary>
		/// The kind of communication protocol this device uses.
		/// </summary>
		public ProviderType kind => this.general?.kind
							?? throw new NullReferenceException("general");

		/// <summary>
		/// 
		/// </summary>
		public ProviderGeneral general { get; set; }
		/// <summary>
		/// This thing's name.
		/// </summary>
		/// <override max-length="100" />
		public string name {
			get => this.general?.name ?? throw new NullReferenceException("general");
			set => (this.general ?? throw new NullReferenceException("general")).name = value;
		}
		/// <summary>
		/// Notes about it.
		/// </summary>
		public string notes {
			get => this.general?.notes ?? throw new NullReferenceException("general");
			set => (this.general ?? throw new NullReferenceException("general")).notes = value;
		}
		/// <summary>
		/// The asset for which this device provides field data.
		/// </summary>
		/// <seealso cref="Asset.id" />
		public ulong? asset {
			get => this.general?.asset ?? throw new NullReferenceException("general");
			set => (this.general ?? throw new NullReferenceException("general")).asset = value;
		}
		/// <summary>
		/// The provider's current (or pending) configuration profile.
		/// </summary>
		/// <seealso cref="ProviderConfig.id" />
		/// <seealso cref="ProviderConfiguration.id" />
		public ulong configuration {
			get => this.general?.configuration ?? throw new NullReferenceException("general");
			set => (this.general ?? throw new NullReferenceException("general")).configuration = value;
		}
		/// <summary>
		/// The password programmed on the device used to ensure the system is the only client authorized to make changes.
		/// </summary>
		/// <override max-length="50" />
		public string password {
			get => this.general?.password ?? throw new NullReferenceException("general");
			set => (this.general ?? throw new NullReferenceException("general")).password = value;
		}
		/// <summary>
		/// The firmware/application version number.
		/// </summary>
		/// <override max-length="100" />
		public string firmware {
			get => this.general?.firmware ?? throw new NullReferenceException("general");
			set => (this.general ?? throw new NullReferenceException("general")).firmware = value;
		}
		/// <summary>
		/// The phone number of this device.
		/// </summary>
		/// <override format="phone" />
		public ulong? phoneNumber {
			get => this.general?.phoneNumber ?? throw new NullReferenceException("general");
			set => (this.general ?? throw new NullReferenceException("general")).phoneNumber = value;
		}
		/// <summary>
		/// A list of read-only values about the device like IMEI, ESN, firmware version, hardware revision, etc...
		/// </summary>
		/// <override>
		/// <keys>
		/// <seealso cref="DataName" />
		/// </keys>
		/// </override>
		public Dictionary<string, string> information {
			get => this.general?.information ?? throw new NullReferenceException("general");
			set => (this.general ?? throw new NullReferenceException("general")).information = value;
		}
		/// <summary>
		/// ICCID of the SIM card installed in this provider
		/// </summary>
		public string sim {
			get => this.general?.sim ?? throw new NullReferenceException("general");
			set => (this.general ?? throw new NullReferenceException("general")).sim = value;
		}

		/// <summary>
		/// 
		/// </summary>
		public ProviderAdvanced advanced { get; set; }
		/// <summary>
		/// The last IP address of the device.
		/// </summary>
		/// <override type="System.String" format="ipv4" />
		public IPEndPoint lastIP {
			get => this.advanced?.lastIP ?? throw new NullReferenceException("advanced");
			set => (this.advanced ?? throw new NullReferenceException("advanced")).lastIP = value;
		}
		/// <summary>
		/// Often changing values like latitude, longitude, speed, wiring state, VBus information, etc...
		/// </summary>
		public Dictionary<string, Dictionary<string, ProviderData>> attributes {
			get => this.advanced?.attributes ?? throw new NullReferenceException("advanced");
			set => (this.advanced ?? throw new NullReferenceException("advanced")).attributes = value;
		}
		/// <summary>
		/// Store-and-forward information like last sequence number of SnF window
		/// </summary>
		public Dictionary<string, string> snf {
			get => this.advanced?.snf ?? throw new NullReferenceException("advanced");
			set => (this.advanced ?? throw new NullReferenceException("advanced")).snf = value;
		}

		/// <summary>
		/// 
		/// </summary>
		public  ProviderControl control { get; set; }
		/// <summary>
		/// Collection of commands for this provider.
		/// </summary>
		public Dictionary<ProviderCommandType, ProviderCommand> commands {
			get => this.control?.commands ?? throw new NullReferenceException("control");
			set => (this.control ?? throw new NullReferenceException("control")).commands = value;
		}

		// IRequestable
		/// <summary>
		/// The <see cref="id"/> is the key.
		/// </summary>
		/// <returns></returns>
		public override string getKey() => this.id;

		// ISuspendable and IDeletable
		/// <summary>
		/// Indicates whether this object was deleted.
		/// </summary>
		public bool? deleted => this.general?.deleted ?? throw new NullReferenceException("general");
		/// <summary>
		/// Indicates whether this object is suspended from event processing.
		/// </summary>
		public bool? suspended => this.general?.suspended ?? throw new NullReferenceException("general");
		/// <summary>
		/// Timestamp from the action that deleted or suspended this object.
		/// </summary>
		public DateTime? since => this.general?.since ?? throw new NullReferenceException("general");
	}
}