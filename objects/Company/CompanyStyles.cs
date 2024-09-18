﻿using System.Collections.Generic;

namespace trakit.objects {
	/// <summary>
	/// The colours and styles used by this company to tag and label Assets, Places, and other things.
	/// </summary>
	public class CompanyStyles : Subscribable, IIdUlong, IAmCompany {
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
		/// The styles for labels added to Assets, Places, and other things.
		/// </summary>
		public Dictionary<string, LabelStyle> labels;
		/// <summary>
		/// The styles for status tags added to Assets.
		/// </summary>
		/// <override type="System.Collections.IDictionary">
		/// <keys type="System.String" format="codified">
		/// <seealso cref="LabelStyle.code" />
		/// </keys>
		/// <values type="Vorgon.LabelStyle" />
		/// </override>
		public Dictionary<string, LabelStyle> tags;
	}
}