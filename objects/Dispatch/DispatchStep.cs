using System;
using System.Collections.Generic;
using System.Linq;

namespace trakit.objects {
	/// <summary>
	/// The lifetime of all <see cref="DispatchStep"/>s (in order).
	/// </summary>
	public enum DispatchStepStatus : byte {
		/// <summary>
		/// The <see cref="DispatchStep"/> has not yet been started.
		/// </summary>
		pending,
		/// <summary>
		/// The asset is on the way to the <see cref="DispatchStep"/>'s location next.
		/// </summary>
		onRoute,
		/// <summary>
		/// The asset has arrived at the <see cref="DispatchStep"/>'s location.
		/// </summary>
		arrived,
		/// <summary>
		/// The <see cref="DispatchStep"/> is done (or the asset has departed the location).
		/// </summary>
		completed,
	}
	/// <summary>
	/// Details about the lifetime of a <see cref="DispatchStep"/>.
	/// </summary>
	public class DispatchStepState {
		/// <summary>
		/// A timestamp from when the lifetime was updated.
		/// </summary>
		public DateTime updated;
		/// <summary>
		/// The coordinates from the <see cref="Asset"/> when the update happened.
		/// </summary>
		public LatLng latlng;
	}

	/// <summary>
	/// A portion of work for a <see cref="DispatchJob"/>.
	/// </summary>
	public class DispatchStep : IIdUlong, INamed {
		/// <summary>
		/// Identifier for this <see cref="DispatchStep"/>.
		/// This value is unique per <see cref="DispatchJob"/>, but is not unique system-wide.
		/// </summary>
		public ulong id{ get; set; }
		/// <summary>
		/// A name for the work needed to be performed.
		/// </summary>
		/// <override max-length="100" />
		public string name { get; set; }
		/// <summary>
		/// The most recently updated state for this step.
		/// </summary>
		public DispatchStepStatus status => this.states.OrderByDescending(p => p.Value.updated).FirstOrDefault().Key;
		/// <summary>
		/// The progress of this step.
		/// </summary>
		public Dictionary<DispatchStepStatus, DispatchStepState> states;
		/// <summary>
		/// The optional estimated time of arrival for the asset.
		/// </summary>
		public DateTime? eta;
		/// <summary>
		/// The optional expected duration of the work for this step.
		/// </summary>
		public TimeSpan? duration;
		/// <summary>
		/// An optional place which can be used as a template instead of providing lat/long coordinates and a street address.
		/// </summary>
		/// <seealso cref="Place.id" />
		public ulong? place;
		/// <summary>
		/// The street address of where the step must be completed.
		/// </summary>
		/// <override max-length="500" />
		public string address;
		/// <summary>
		/// The lat/long coordinates of where the step must be <see cref="DispatchStepStatus.completed"/>.
		/// </summary>
		public LatLng latlng;
		/// <summary>
		/// Notes about the status of the work filled in by field-employee.
		/// </summary>
		public string notes { get; set; }
		/// <summary>
		/// Indicates whether this step requires a signature.
		/// </summary>
		public bool signature;
		/// <summary>
		/// The name of the person who signed the step's completion.
		/// </summary>
		/// <override max-length="100" />
		public string? signatory;
	}
}