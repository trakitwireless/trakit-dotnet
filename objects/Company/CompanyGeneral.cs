﻿using System.Collections.Generic;

namespace trakit.objects {
	/// <summary>
	/// General details about a company.
	/// </summary>
	/// <category>Companies</category>
	public class CompanyGeneral : Subscribable, IIdUlong, INamed, IAmCompany {
		/// <summary>
		/// Unique identifier of the Company.
		/// </summary>
		/// <seealso cref="Company.id" />
		public ulong id { get; set; }
		/// <summary>
		/// The unique identifier of this company's parent organization.
		/// </summary>
		/// <seealso cref="Company.id" />
		public ulong parent { get; set; }
		/// <summary>
		/// The organizational name.
		/// </summary>
		/// <override max-length="100" />
		public string name { get; set; }
		/// <summary>
		/// Notes.
		/// </summary>
		public string notes { get; set; }
		/// <summary>
		/// Name/value collections of custom fields used to refer to external systems.
		/// </summary>
		/// <override max-count="10">
		/// <keys max-length="20" />
		/// <values max-length="100" />
		/// </override>
		public Dictionary<string, string> references;
	}
}