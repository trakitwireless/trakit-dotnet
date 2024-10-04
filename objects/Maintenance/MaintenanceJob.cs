﻿using System;
using System.Collections.Generic;

namespace trakit.objects {
	/// <summary>
	/// Historical service work performed on a Vehicle or Trailer
	/// </summary>
	public class MaintenanceJob : Subscribable, IIdUlong, INamed, IBelongCompany, IBelongAsset, IPictured, IDeletable {
		/// <summary>
		/// Default threshold (in minutes) for the valid completion date of jobs.
		/// </summary>
		public const int DEFAULT_COMPLETED_THRESHOLD_MINUTES = 10;

		/// <summary>
		/// Unique identifier
		/// </summary>
		public ulong id { get; set; }
		/// <summary>
		/// The Vehicle or Trailer to which this job belongs
		/// </summary>
		/// <seealso cref="Asset.id" />
		public ulong asset { get; set; }
		/// <summary>
		/// The company to which this Vehicle or Trailer belongs
		/// </summary>
		/// <seealso cref="Company.id" />
		public ulong company { get; set; }
		/// <summary>
		/// The Maintenance Schedule from which this job was created
		/// </summary>
		/// <seealso cref="MaintenanceSchedule.id" />
		public ulong? schedule { get; set; }
		/// <summary>
		/// The work being done. Like "oil change".
		/// </summary>
		/// <override max-length="100" />
		public string name { get; set; }
		/// <summary>
		/// Notes about the job.  Like "changed the oil and filter".
		/// </summary>
		public string notes { get; set; }
		/// <summary>
		/// The status of this job.
		/// </summary>
		public MaintenanceJobStatus status;
		/// <summary>
		/// When was this job created.
		/// </summary>
		public DateTime created;
		/// <summary>
		/// When was this job created.
		/// </summary>
		public DateTime? completed;
		/// <summary>
		/// The odometer at the time of the service.
		/// </summary>
		public double? odometer;
		/// <summary>
		/// The operating time at the time of the service.
		/// </summary>
		public double? engineHours;

		// ------------ repair details ------------
		/// <summary>
		/// The name of the garage or service facility where the work is done.
		/// </summary>
		/// <override max-length="100" />
		public string garage;
		/// <summary>
		/// Time it took to complete the job.
		/// </summary>
		/// <override format="timespan" />
		public TimeSpan duration;
		/// <summary>
		/// How much the job cost in dollars.
		/// </summary>
		public double cost;
		/// <summary>
		/// A reference code used to track this job
		/// </summary>
		/// <override max-length="100" />
		public string reference;
		/// <summary>
		/// The mechanic who performed the work.
		/// </summary>
		/// <override max-length="100" />
		public string technician;
		/// <summary>
		/// Images taken while performing the work for reference.
		/// </summary>
		/// <seealso cref="Picture.id" />
		/// <override>
		/// <values>
		/// <seealso cref="Picture.id" />
		/// </values>
		/// </override>
		public List<ulong> pictures { get; set; }

		// IRequestable
		/// <summary>
		/// The <see cref="id"/> is the key.
		/// </summary>
		/// <returns></returns>
		public override string getKey() => this.id.ToString();

		// IDeletable
		/// <summary>
		/// Indicates whether this object was deleted.
		/// </summary>
		public bool? deleted { get; set; }
		/// <summary>
		/// Timestamp from the action that deleted or suspended this object.
		/// </summary>
		public DateTime? since { get; set; }
	}
}