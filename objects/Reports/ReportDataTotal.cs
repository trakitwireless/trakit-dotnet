using System;

namespace trakit.objects {
	/// <summary>
	/// Totalled information from all the results of the report.
	/// </summary>
	/// <category>Reports</category>
	/// <override name="ReportTotal" />
	public class ReportDataTotal {
		/// <summary>
		/// The asset to which this report total belongs.
		/// </summary>
		/// <seealso cref="Asset.id" />
		public ulong asset;
		/// <summary>
		/// Unique code given to the report total.
		/// </summary>
		/// <override max-length="100" />
		public string stateDetail;
		/// <summary>
		/// The number of summary instances included in this total.
		/// </summary>
		public uint summaryCount;
		/// <summary>
		/// The total duration of all summary instances.
		/// </summary>
		public TimeSpan duration;
		/// <summary>
		/// The total distance travelled in kilometres of all summary instances.
		/// </summary>
		public double distance;
	}
}