using System;

namespace trakit.objects {
	/// <summary>
	/// The detail for calculating Maintenance Schedule recurrence.
	/// </summary>
	/// <category>Maintenance</category>
	/// <override name="MaintenanceInterval" />
	public class MaintenanceRecurrence : IBelongAsset {
		/// <summary>
		/// The Vehicle or Trailer to which this recurrence detail belongs.
		/// </summary>
		/// <seealso cref="Asset.id" />
		public ulong asset { get; set; }
		/// <summary>
		/// The date of the last calculation.
		/// </summary>
		public DateTime date;
		/// <summary>
		/// The odometer at the time of the last calculation.
		/// </summary>
		public double odometer;
		/// <summary>
		/// The operating time at the time of the last calculation.
		/// </summary>
		public double engineHours;
		/// <summary>
		/// The last "completed" job related to this schedule interval.
		/// </summary>
		public ulong lastJob;
	}
}