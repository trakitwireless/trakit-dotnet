using System;
using System.Collections.Generic;

namespace trakit.objects {
	/// <summary>
	/// Rules used for generating a scorecard.
	/// </summary>
	public class ReportScorecardRules {
		/// <summary>
		/// Base score for the scorecard.
		/// </summary>
		public double baseScore;
		/// <summary>
		/// Infraction parameters used to generate the final score
		/// </summary>
		public List<ReportScorecardParameter> parameters;
	}

	/// <summary>
	/// Infraction parameter used to generate scorecard
	/// </summary>
	public class ReportScorecardParameter {
		/// <summary>
		/// Type of exception, example speeding, idling, etc.
		/// </summary>
		public string condition;
		/// <summary>
		/// Threshold per instance. If the threshold is 0, each instance is used in the calculation
		/// </summary>
		public TimeSpan duration;
		/// <summary>
		/// Points applied against the base score per instance
		/// </summary>
		public double points;
	}

	/// <summary>
	/// Scorecard generated from the results of this report.
	/// </summary>
	public class ReportScorecard {
		/// <summary>
		/// The asset to which this scorecard belongs.
		/// </summary>
		/// <seealso cref="Asset.id" />
		public ulong asset;
		/// <summary>
		/// Final score calculated based on scorecard rules.
		/// </summary>
		public double score;
		/// <summary>
		/// Points per rule
		/// </summary>
		public Dictionary<string, double> rulePoints;
	}
}