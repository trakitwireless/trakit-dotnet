﻿using System.Collections.Generic;

namespace trakit.objects {
	/// <summary>
	/// Drill-down mechanism for highlighting only those places and regions desired in report results.
	/// </summary>
	public enum ReportFilterMode : byte {
		/// <summary>
		/// Filtering is not enabled for the report.
		/// </summary>
		none,
		/// <summary>
		/// Include any results for those whose filters match.
		/// </summary>
		inclusive,
		/// <summary>
		/// Exclude all results except those whose filters match.
		/// </summary>
		exclusive,
	}

	/// <summary>
	/// The options used by the report runner to process results.
	/// </summary>
	public class ReportOptions {
		/// <summary>
		/// A list of parameters to better shape the results.
		/// </summary>
		public List<ReportParameter> parameters;
		/// <summary>
		/// A targeting expression for including/excluding Assets.
		/// </summary>
		/// <override type="System.String" format="expression" />
		public string targets;
		/// <summary>
		/// The mechanism to use for filtering based on places and regions.
		/// </summary>
		public ReportFilterMode filtering;
		/// <summary>
		/// A targeting expression for limiting results which only include data from Assets interacting with the targeted Places.
		/// </summary>
		/// <override type="System.String" format="expression" />
		public string places;
		/// <summary>
		/// A list of provinces and states, where only assets within those regions will be included in the results.
		/// </summary>
		public List<string> regions;
		/// <summary>
		/// Rules used to generate scorecard for this report.
		/// </summary>
		public ReportScorecardRules? scorecardRules;
	}
}