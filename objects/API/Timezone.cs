namespace trakit.objects {
	/// <summary>
	/// Timezone definition
	/// </summary>
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
}