using System;
using System.Collections.Generic;

namespace trakit.objects {
	/// <summary>
	/// The type of logic used by the report runner.
	/// </summary>
	public enum ReportType : byte {
		/// <summary>
		/// Invalid report type
		/// </summary>
		/// <override skip="true" />
		unknown = 0,
		/// <summary>
		/// Processes all history for the assets.
		/// </summary>
		full,
		/// <summary>
		/// Summarizes the timeline based on the given tags.
		/// </summary>
		tags,
		/// <summary>
		/// Summarizes the timeline based on places visited.
		/// </summary>
		places,
		/// <summary>
		/// Processes the log of messages sent to and from the assets.
		/// </summary>
		messages,
		/// <summary>
		/// Summarizes the timeline based on the asset's task's lifetimes.
		/// </summary>
		[Obsolete("Use `ReportType.jobs` instead")]
		tasks,
		/// <summary>
		/// Summarizes the timeline based on the given attributes and thresholds.
		/// </summary>
		attributes,
		/// <summary>
		/// Summarizes the timeline based on the regions (cities, provinces/states, countries) through which the assets travelled.
		/// </summary>
		regions,
		/// <summary>
		/// Summarizes the timeline based on the asset's jobs's lifetimes.
		/// </summary>
		jobs,
		/// <summary>
		/// Summarizes the timeline by day, week, and month based on the asset's positions.
		/// </summary>
		positions,
	}

	/// <summary>
	/// The lifetime of building a <see cref="ReportResult"/>.
	/// </summary>
	public enum ReportStatus : byte {
		/// <summary>
		/// The <see cref="ReportResult"/> has been requested, but not yet begun processing.
		/// </summary>
		created,
		/// <summary>
		/// The <see cref="ReportResult"/> is waiting for required resources to begin processing.
		/// </summary>
		queued,
		/// <summary>
		/// The <see cref="ReportResult"/> is currently being processed.
		/// </summary>
		running,
		/// <summary>
		/// The <see cref="ReportResult"/> results have been calculated, and are being saved for review.
		/// </summary>
		saving,
		/// <summary>
		/// The <see cref="ReportResult"/> is available for retrieval.
		/// </summary>
		completed,
		/// <summary>
		/// There was an error processing the <see cref="ReportResult"/>; see the <see cref="ReportResult.error"/> for a description.
		/// </summary>
		failed,
	}

	/// <summary>
	/// Report results
	/// </summary>
	public class ReportResult : Subscribable, IIdUlong, INamed, IBelongCompany {
		/// <summary>
		/// Unique identifier
		/// </summary>
		public ulong id { get; set; }
		/// <summary>
		/// The company to which this report belongs
		/// </summary>
		/// <seealso cref="Company.id" />
		public ulong company { get; set; }
		/// <summary>
		/// Refers to the type of logic used by this report.
		/// </summary>
		public ReportType kind { get; set; }
		/// <summary>
		/// Name of this report.
		/// </summary>
		/// <override max-length="100" />
		public string name { get; set; }
		/// <summary>
		/// Notes about this report.
		/// </summary>
		public string notes { get; set; }
		/// <summary>
		/// Specified parameters for the report logic, targeted Assets, and filtering Places.
		/// </summary>
		public ReportOptions options;
		/// <summary>
		/// A reference to the Template used to create this result.  This field is optional because templates are not necessarily required; they just make life a lot easier.
		/// </summary>
		/// <seealso cref="ReportTemplate.id" />
		public ulong? template;
		/// <summary>
		/// A reference to the schedule used to create this result.
		/// This field is optional as not all results are created on a schedule.
		/// </summary>
		/// <seealso cref="ReportSchedule.id" />
		public ulong? schedule;
		/// <summary>
		/// Preserve these results for later review.  Results are regularly culled from the system.
		/// </summary>
		public bool archive;
		/// <summary>
		/// The timezone code used to adjust dates/times used in processing and saving this report.
		/// </summary>
		/// <seealso cref="Timezone.code" />
		/// <override type="System.String" format="codified" />
		public TimeZoneInfo timezone;
		/// <summary>
		/// The login of the user that ran this report.
		/// </summary>
		/// <seealso cref="User.login" />
		/// <override max-length="254" format="email" />
		public string runBy;
		/// <summary>
		/// The date/time this result was requested.
		/// </summary>
		public DateTime created;
		/// <summary>
		/// The date/time this result was finished processing.
		/// </summary>
		public DateTime? completed;
		/// <summary>
		/// The processing status of this report.
		/// </summary>
		public ReportStatus status;
		/// <summary>
		/// The progress in processing/saving this result is a number between 0 and 100.
		/// </summary>
		public byte progress;
		/// <summary>
		/// After processing, the boundary of the results are given so that a map can be focused on that area.
		/// </summary>
		public LatLngBounds bounds;
		/// <summary>
		/// When the report runs, a list of targeted assets is calculated based on the ReportOption's targeting expression.
		/// </summary>
		public ulong[]? targeted;
		/// <summary>
		/// When the report runs, a list of filtered places is calculated based on the ReportOption's place filtering expression.
		/// </summary>
		public ulong[]? filtered;
		/// <summary>
		/// After processing, the report totals the values from all summary instances for a quick overview of the kind of results generated.
		/// </summary>
		public List<ReportDataTotal>? totals;
		/// <summary>
		/// Scorecards for all the targeted assets based on the scorecard rules.
		/// </summary>
		public List<ReportScorecard>? scorecards;
		/// <summary>
		/// A field which contains report error details if the <see cref="status"/> is <see cref="ReportStatus.failed"/>.
		/// </summary>
		/// <seealso cref="ReportStatus" />
		/// <override max-length="250" />
		public string error;
	}

	/// <summary>
	/// Report results which also include the computed summary and breakdown for the results.
	/// </summary>
	public class ReportResultData : ReportResult {
		/// <summary>
		/// Grouped events form a summary instance, and contain information about the starting, ending, and number of the grouped events.
		/// </summary>
		public Dictionary<ulong, List<ReportDataSummaryInstance>>? summary;
		/// <summary>
		/// Individual events about the targeted assets used to calculate the results of the report.
		/// </summary>
		public Dictionary<ulong, List<ReportDataBreakdownInstance>>? breakdown;
	}
}