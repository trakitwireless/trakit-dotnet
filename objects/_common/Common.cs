namespace trakit.objects {
	/// <summary>
	/// Timezone definition
	/// </summary>
	/// <category>API Definitions</category>
	public class Timezone {
		/// <summary>
		/// Unique timezone code
		/// </summary>
		/// <override format="codified" readonly="true" />
		public string code;
		/// <summary>
		/// Common timezone name
		/// </summary>
		/// <override readonly="true" />
		public string name;
		/// <summary>
		/// Minutes offset from GMT
		/// </summary>
		/// <override readonly="true" />
		public short offset;
		/// <summary>
		/// Indicates whether this timezone abides by daylight savings
		/// </summary>
		/// <override readonly="true" />
		public bool dst;
	}

	/// <summary>
	/// Part of the White-labelling profile definitions.
	/// </summary>
	/// <category>White-labelling</category>
	public class ColourStyle {
		/// <summary>
		/// The colour of the background.
		/// </summary>
		/// <override max-length="22" format="colour" />
		public string fill;
		/// <summary>
		/// The colour of the text or outline.
		/// </summary>
		/// <override max-length="22" format="colour" />
		public string stroke;
	}
}