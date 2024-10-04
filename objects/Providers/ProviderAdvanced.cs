﻿using System.Collections.Generic;
using System.Net;

namespace trakit.objects {
	/// <summary>
	/// Device/hardware information reported from the field.
	/// </summary>
	public class ProviderAdvanced : Subscribable, IBelongCompany {
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
		/// The last IP address of the device.
		/// </summary>
		/// <override type="System.String" format="ipv4" />
		public IPEndPoint lastIP;
		/// <summary>
		/// Often changing values like latitude, longitude, speed, wiring state, VBus information, etc...
		/// </summary>
		public Dictionary<string, Dictionary<string, ProviderData>> attributes;
		/// <summary>
		/// Store-and-forward information like last sequence number of SnF window
		/// </summary>
		public Dictionary<string, string> snf;

		// IRequestable
		/// <summary>
		/// The <see cref="id"/> is the key.
		/// </summary>
		/// <returns></returns>
		public override string getKey() => this.id;
	}
}