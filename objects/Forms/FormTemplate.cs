﻿using System;

namespace trakit.objects {
	/// <summary>
	/// The full definition of a form that needs to be filled out.
	/// </summary>
	public class FormTemplate : Component, IIdUlong, INamed, IBelongCompany, ILabelled, IVisual, IDeletable {
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
		public string[] labels { get; set; }
		/// <summary>
		/// The fill/background colour of the icon.
		/// </summary>
		/// <override max-length="22" format="colour" />
		public string fill { get; set; }
		/// <summary>
		/// Outline and graphic colour.
		/// </summary>
		/// <override max-length="22" format="colour" />
		public string stroke { get; set; }
		/// <summary>
		/// The name of the symbol for this template.
		/// </summary>
		/// <override max-length="22" format="codified" />
		public string graphic { get; set; }
		/// <summary>
		/// All the user fillable fields by name.
		/// </summary>
		public FormFieldBase[] fields;

		// IRequestable
		/// <summary>
		/// The <see cref="id"/> is the key.
		/// </summary>
		/// <returns></returns>
		public override string getKey() => this.id.ToString();

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