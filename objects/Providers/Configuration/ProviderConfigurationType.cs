using System;
using System.Collections.Generic;

namespace trakit.objects {
	/// <summary>
	/// This tree-like structure is given to the script processor for the device type so that the device can follow a program.
	/// </summary>
	[Obsolete("Use ProviderScriptBlock instead")]
	public class ProviderConfigurationNode {
		/// <summary>
		/// Indicates that this configuration is an advanced property and should only be set by someone who knows what they're doing.
		/// </summary>
		public bool isAdvanced = true;
		/// <summary>
		/// Unique identifier of the value being mapped.
		/// </summary>
		public string id = string.Empty;
		/// <summary>
		/// The value being set.
		/// </summary>
		public object value;
		/// <summary>
		/// The minimum possible value for this confugration node.
		/// </summary>
		public object? min;
		/// <summary>
		/// The maximum possible value for this confugration node.
		/// </summary>
		public object? max;
		/// <summary>
		/// Type hint used by the script processor to help format the value.
		/// </summary>
		public string? type;
		/// <summary>
		/// Unit hint used to help the script processor format the value.
		/// </summary>
		/// <override type="Vorgon.Units" />
		public string? unit;
		/// <summary>
		/// Description of what this configuration does when mapped to a device.
		/// </summary>
		public string? notes;
		/// <summary>
		/// Child configuration nodes.
		/// </summary>
		public Dictionary<string, ProviderConfigurationNode> nodes;
	}

	/// <summary>
	/// An abstract class used as a base for all Geofence type classes.
	/// </summary>
	[Obsolete]
	public abstract class GeofenceType {
		/// <summary>
		/// The supported shape of geofence.
		/// </summary>
		public PlaceType type;
		/// <summary>
		/// The maximum number of unique geofences supported by the device.
		/// </summary>
		public uint maxGeofenceCount;
	}
	/// <summary>
	/// A geofence whose boundary is defined by a non-overlapping series of coordinates.
	/// </summary>
	/// <override skip="false" name="" />
	[Obsolete]
	public class ProviderGeofencePolygon : GeofenceType {
		/// <summary>
		/// The maximum number of vertices supported by the device.
		/// </summary>
		public uint maxVertices;
	}
	/// <summary>
	/// A geofence defined by a centre coordinate and a threshold value to indicate the boundary around that point.
	/// </summary>
	/// <override skip="false" name="" />
	[Obsolete]
	public class ProviderGeofenceCircular : GeofenceType {
		/// <summary>
		/// The smallest possible radius for this geofence.
		/// </summary>
		public uint minRadius;
		/// <summary>
		/// The largest possible radius for this geofence.
		/// </summary>
		public uint maxRadius;
	}
	/// <summary>
	/// A geofence whose boundary is a "rectangle" defined by corner coordinates.
	/// </summary>
	[Obsolete]
	public class ProviderGeofenceRectangle : GeofenceType {
		/// <summary>
		/// The smallest possible diameter for this geofence.
		/// </summary>
		/// <override type="System.UInt32" />
		public int maxLength;
		/// <summary>
		/// The smallest possible diameter for this geofence.
		/// </summary>
		/// <override type="System.UInt32" />
		public int maxWidth;
	}
	/// <summary>
	/// This is a point and not a geofence, so I don't know why this is defined.
	/// </summary>
	/// <override skip="false" name="" />
	[Obsolete]
	public class ProviderGeofencePoint : GeofenceType { }

	/// <summary>
	/// This read-only class describes a type of logic applied to a provider.
	/// ProviderConfigurationTypes are used to help define a ProviderConfiguration.
	/// </summary>
	[Obsolete("Use ProviderScript instead")]
	public class ProviderConfigurationType : Subscribable, IIdUlong, INamed {
		/// <summary>
		/// Unique identifier.
		/// </summary>
		public ulong id { get; set; }
		/// <summary>
		/// Name of the configuration type.
		/// </summary>
		/// <override max-length="100" />
		public string name { get; set; }
		/// <summary>
		/// Notes regarding the use of this configuration.
		/// </summary>
		public string notes { get; set; }
		/// <summary>
		/// The applicable type of provider for which this configuration type can be created.
		/// </summary>
		public ProviderType providerType;
		/// <summary>
		/// The maximum number of geofences that can be programmed onto a device. This number changes based on device make and model, and can also change based on the supported geofence types.
		/// </summary>
		/// <override type="System.UInt32" />
		public int maxGeofenceCount;
		/// <summary>
		/// The minimum number of geofences that need to be programmed onto the device. This value is almost always zero.
		/// </summary>
		/// <override type="System.UInt32" />
		public int minGeofenceCount;
		/// <summary>
		/// A tree-structure of configurations required (or optionally available) for programming a device.
		/// </summary>
		public Dictionary<string, ProviderConfigurationNode> scriptOptions;
		/// <summary>
		/// A list of supported types of geofences which can be programmed directly onto the device.
		/// </summary>
		public PlaceType[] geofenceTypes;
	}
}