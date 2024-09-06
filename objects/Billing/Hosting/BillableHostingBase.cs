namespace trakit.objects {
	/// <summary>
	/// Hosted things share a lot of common attributes.
	/// </summary>
	/// <category>Billing</category>
	public abstract class BillableHostingBase : BillableBase {
		/// <summary>
		/// The number of units to which this billing rule applies.
		/// Should be a non-zero value; null means unlimited
		/// </summary>
		public uint? limit;
		/// <summary>
		/// Which assets are targeted by this hosting rule
		/// </summary>
		/// <override type="System.String" format="expression" />
		public SearchPattern[] targets;
		/// <summary>
		/// Does this hosting rule apply to suspended resources
		/// </summary>
		public bool suspended { get; set; }
			}
}