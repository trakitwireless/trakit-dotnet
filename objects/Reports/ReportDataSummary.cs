using System;
using System.Collections.Generic;

namespace trakit.objects {
	/// <summary>
	/// The kind of reason associated with the range caps for a summary instance.
	/// </summary>
	/// <category>Reports</category>
	public enum ReportDataSummaryReason : byte {
		/// <summary>
		/// If the report starting/ending date range overlaps the actual start of the state.
		/// </summary>
		outsideRange,
		/// <summary>
		/// The targeting query starts or stops matching.  For example, the Asset's labels were changed.
		/// </summary>
		targeted,
		/// <summary>
		/// The asset started/stopped matching the required state.  For example, a status tag was added or removed.
		/// </summary>
		stateMatch,
		/// <summary>
		/// The summary instance elapsed a Rubicon or prolonged parameter, and was split into two summary instances.
		/// </summary>
		/// <seealso cref="ReportParameterType" />
		split,
		/// <summary>
		/// The asset started/stopped matching the report filter settings. For example, they left a province or entered a Place.
		/// </summary>
		/// <seealso cref="ReportFilterMode" />
		filterMatch,
	}

	/// <summary>
	/// Summarized asset details.
	/// </summary>
	/// <category>Reports</category>
	/// <override name="ReportSummary" />
	public class ReportDataSummaryInstance {
		/// <summary>
		/// The asset to which this summary instance belongs.
		/// </summary>
		/// <seealso cref="Asset.id" />
		public ulong asset;
		/// <summary>
		/// Code given to this summary instance for an asset.
		/// </summary>
		/// <override max-length="100" />
		public string stateDetail;
		/// <summary>
		/// Identifier of the summary instance in the report.
		/// </summary>
		public uint instance;
		/// <summary>
		/// The number of events included in calculating this summary instance.
		/// </summary>
		public uint instancesCount;
		/// <summary>
		/// Date/time stamp of the first event in this summary's sequence.
		/// </summary>
		public DateTime startingUtc;
		/// <summary>
		/// The reason code that this summary instance began.
		/// </summary>
		public ReportDataSummaryReason startingReason;
		/// <summary>
		/// Date/time stamp of the last event in this summary's sequence.
		/// </summary>
		public DateTime endingUtc;
		/// <summary>
		/// The reason code that this summary instance ended.
		/// </summary>
		public ReportDataSummaryReason endingReason = ReportDataSummaryReason.outsideRange;
		/// <summary>
		/// The distance travelled in kilometres by the asset during this summary instance.
		/// </summary>
		public double distance{ get; set; }
		/// <summary>
		/// The amount of time that passed.
		/// </summary>
		public TimeSpan duration => this.endingUtc - this.startingUtc;
		/// <summary>
		/// A simplified polyline of all the asset's positions in sequence.
		/// </summary>
		public List<LatLng> polyline = new List<LatLng>();
		/// <summary>
		/// The first asset state which begins this summary instance.
		/// </summary>
		public Asset firstState;
		/// <summary>
		/// The asset state that ended this summary instance.
		/// </summary>
		public Asset lastState;
	}
}