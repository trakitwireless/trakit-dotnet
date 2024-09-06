using System;
using System.Collections.Generic;

namespace trakit.objects {
	/// <summary>
	/// Tasks have a lifetime and each status represents a task's progress through it's life.
	/// </summary>
	/// <category>Dispatch</category>
	[Obsolete("Use DispatchStepStatus instead")]
	public enum TaskStatus : byte {
		/// <summary>
		/// The task has been created, but not yet assigned to an asset.
		/// </summary>
		created,
		/// <summary>
		/// The task has been given to an asset (and delivered to the asset's primary device).
		/// </summary>
		queued,
		/// <summary>
		/// The asset is on the way to the task's location next.
		/// </summary>
		onRoute,
		/// <summary>
		/// The asset has arrived at the task's location.
		/// </summary>
		arrived,
		/// <summary>
		/// The task is done.
		/// </summary>
		completed,
		/// <summary>
		/// The task was cancelled by either the asset or a user.
		/// </summary>
		cancelled,
		/// <summary>
		/// An item was picked-up for this task.
		/// </summary>
		pickedUp,
		/// <summary>
		/// An item was dropped-off for this task.
		/// </summary>
		droppedOff,
		/// <summary>
		/// The asset is waiting and can't complete the task.
		/// </summary>
		waiting,
		/// <summary>
		/// An item associated with this task is damaged.
		/// </summary>
		damaged,
		/// <summary>
		/// The task couldn't be completed by the asset.
		/// </summary>
		unsuccessful,
	}

	/// <summary>
	/// A task assigned to an asset which represents a coordinate on the map which must be visited.
	/// </summary>
	/// <category>Dispatch</category>
	[Obsolete("Use DispatchJob instead")]
	public class DispatchTask : Subscribable, IIdUlong, IDeletable, IBelongCompany, IBelongAsset {
		/// <summary>
		/// Unique identifier of this task.
		/// </summary>
		public ulong id { get; set; }
		/// <summary>
		/// The company to which this task belongs.
		/// </summary>
		/// <seealso cref="Company.id" />
		public ulong company { get; set; }
		/// <summary>
		/// The asset to which this task belongs.
		/// </summary>
		/// <seealso cref="Asset.id" />
		public ulong asset { get; set; }
		/// <summary>
		/// The name of this task or the work needed to be performed.
		/// </summary>
		/// <override max-length="100" />
		public string name;
		/// <summary>
		/// Name/value collections of custom fields used to refer to external systems.
		/// </summary>
		/// <override max-count="10">
		/// <keys max-length="20" />
		/// <values max-length="100" />
		/// </override>
		public Dictionary<string, string> references;
		/// <summary>
		/// An optional place which can be used as a template instead of providing lat/long coordinates and a street address.
		/// </summary>
		/// <seealso cref="Place.id" />
		public ulong? place;
		/// <summary>
		/// The street address of where the task must be completed.
		/// </summary>
		/// <override max-length="500" />
		public string address;
		/// <summary>
		/// The lat/long coordinates of where the task must be completed.
		/// </summary>
		public LatLng latlng;
		public bool deleted { get; set; }
		/// <summary>
		/// The progress of this task.
		/// </summary>
		public TaskStatus status;
		/// <summary>
		/// When this task was created.
		/// </summary>
		public DateTime created;
		/// <summary>
		/// The optional estimated time of arrival for the asset.
		/// </summary>
		public DateTime? eta;
		/// <summary>
		/// The optional expected duration of the work for this task.
		/// </summary>
		public TimeSpan? duration;
		/// <summary>
		/// The date/time stamp of when the asset arrived at this task.
		/// </summary>
		public DateTime? arrived;
		/// <summary>
		/// The date/time stamp of when this task was completed.
		/// </summary>
		public DateTime? completed;
		/// <summary>
		/// Instructions (filled out by dispatcher) for the field-employee to help them completed the task.
		/// </summary>
		public string instructions;
		/// <summary>
		/// Indicates whether the task has a signature.
		/// </summary>
		public bool signature;
		/// <summary>
		/// The name of the person who signed the task's completion.
		/// </summary>
		/// <override max-length="100" />
		public string signatory;
		/// <summary>
		/// Notes about the status of the work filled in by field-employee.
		/// </summary>
		public string notes;
		/// <summary>
		/// A list of hosted <see cref="Document"/> identifiers attached to this task.
		/// </summary>
		/// <override max-count="10">
		/// <values>
		/// <seealso cref="Document.id" />
		/// </values>
		/// </override>
		public List<ulong> attachments;
		/// <summary>
		/// Either the user's login, or provider's identifier that changed this task
		/// </summary>
		public string updatedBy;
		/// <summary>
		/// Timestamp from the last change made to this task
		/// </summary>
		public DateTime updatedUtc;
	}
}