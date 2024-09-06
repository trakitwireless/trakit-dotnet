﻿using System;

namespace trakit.objects {
	/// <summary>
	/// A control to choose a date and (optionally) a time.
	/// </summary>
	/// <category>File Hosting</category>
	public class FormFieldDate : FormFieldBase {
		/// <summary>
		/// These are the calendar control types.
		/// </summary>
		protected override FormFieldType[] supported => new[] {
			FormFieldType.date,
			FormFieldType.datetime,
		};

		/// <summary>
		/// The earliest date or date/time.
		/// </summary>
		public DateTime? minimum;
		/// <summary>
		/// The latest date or date/time.
		/// </summary>
		public DateTime? maximum;
	}
}