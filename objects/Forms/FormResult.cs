﻿using System;
using System.Collections.Generic;

namespace trakit.objects {
	/// <summary>
	/// A completed form submitted by a <see cref="User"/> or <see cref="Asset"/>.
	/// </summary>
	public class FormResult : Subscribable, IIdUlong, INamed, IBelongCompany, ILabelled, IDeletable {
		/// <summary>
		/// Unique identifier of this form.
		/// </summary>
		public ulong id { get; set; }
		/// <summary>
		/// The <see cref="Company"/> to which this form belongs.
		/// </summary>
		/// <seealso cref="Company.id" />
		public ulong company { get; set; }
		/// <summary>
		/// The <see cref="FormTemplate"/> to which this form belongs.
		/// </summary>
		public ulong template { get; set; }
		/// <summary>
		/// The <see cref="Asset"/> to which this form belongs.
		/// </summary>
		/// <seealso cref="Asset.id" />
		public ulong? asset;
		/// <summary>
		/// Name of this form.
		/// </summary>
		/// <override max-length="100" />
		public string name { get; set; }
		/// <summary>
		/// Notes about this form.
		/// </summary>
		public string notes { get; set; }
		/// <summary>
		/// Codified label names used to relate forms to <see cref="Asset"/>s.
		/// </summary>
		/// <override>
		/// <values format="codified">
		/// <seealso cref="LabelStyle.code" />
		/// </values>
		/// </override>
		public List<string> labels { get; set; }
		/// <summary>
		/// All the values for fillable fields by index.
		/// </summary>
		public Dictionary<ulong, string> fields;
		/// <summary>
		/// A timestamp from when this form was completed by a <see cref="User"/> or <see cref="Asset"/>.
		/// </summary>
		public DateTime? completed;
		/// <summary>
		/// The coordinates of the <see cref="User"/> or <see cref="Asset"/> from when the form was completed.
		/// </summary>
		public LatLng latlng;
		/// <summary>
		/// Clocked-in driver name who made the update.
		/// Null if not clocked-in, or no changes have been made.
		/// </summary>
		public string driver;

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