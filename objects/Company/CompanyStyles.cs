using System;
using System.Collections.Generic;

namespace trakit.objects {
	/// <summary>
	/// The colours and styles used by this company to tag and label Assets, Places, and other things.
	/// </summary>
	/// <category>Companies</category>
	public class CompanyStyles : Subscribable, IIdUlong, IAmCompany {
		/// <summary>
		/// Unique identifier of the Company.
		/// </summary>
		/// <seealso cref="Company.id" />
		public ulong id{ get; set; }
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

	/// <summary>
	/// Visual style identification helper.
	/// </summary>
	/// <category>Companies</category>
	public class LabelStyle : INamed, IVisual {
		/// <summary>
		/// The name of this visual style.
		/// </summary>
		/// <override max-length="100" />
		public string name { get; set; }
		/// <summary>
		/// The codified name of this style
		/// </summary>
		/// <override readonly="true" format="codified" />
		public string code{ get; set; }
		/// <summary>
		/// The background colour given to this style for easy visual identification.
		/// </summary>
		/// <override max-length="22" format="colour" />
		public string fill { get; set; }
		/// <summary>
		/// The text/graphic colour given to this style for easy visual identification.
		/// </summary>
		/// <override max-length="22" format="colour" />
		public string stroke { get; set; }
		/// <summary>
		/// The codified graphic name given to this script for easy visual identification.
		/// </summary>
		/// <override max-length="22" format="codified" />
		public string graphic { get; set; }
		/// <summary>
		/// Notes!
		/// </summary>
		public string notes { get; set; }
	}
}