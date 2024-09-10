using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace trakit.objects {
	/// <summary>
	/// Asset information used in calculating a summary instance.
	/// </summary>
	/// <override name="ReportBreakdown" />
	public class ReportDataBreakdownInstance {
		/// <summary>
		/// The asset to which this event data belongs.
		/// </summary>
		public ulong asset;
		/// <summary>
		/// Report specific identifier of the event data.
		/// </summary>
		public uint instance;
		/// <summary>
		/// Identifiers of the summary instances that used this event.
		/// </summary>
		public List<uint> summaryInstances;
		/// <summary>
		/// General Asset information.
		/// </summary>
		public AssetGeneral general;
		/// <summary>
		/// Advanced/detailed information used.
		/// </summary>
		public AssetAdvanced advanced;
	}
	/// <summary>
	/// Message information used in this report.
	/// </summary>
	/// <override skip="false" name="ReportBreakdownMessage" />
	public class ReportDataBreakdownMessage : ReportDataBreakdownInstance {
		/// <summary>
		/// The Message used.
		/// </summary>
		public AssetMessage message;
	}
	/// <summary>
	/// Dispatch Task information used in this report.
	/// </summary>
	/// <override skip="false" name="ReportBreakdownTask" />
	public class ReportDataBreakdownTask : ReportDataBreakdownInstance {
		/// <summary>
		/// The Task used.
		/// </summary>
		public DispatchTask task;
	}
	/// <summary>
	/// Dispatch Job information used in this report.
	/// </summary>
	/// <override skip="false" name="ReportBreakdownJob" />
	public class ReportDataBreakdownJob : ReportDataBreakdownInstance {
		/// <summary>
		/// The Job used.
		/// </summary>
		public DispatchJob job;
	}
}