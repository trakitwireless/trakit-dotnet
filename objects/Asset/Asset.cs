using System.Collections.Generic;
using System.Linq;

namespace trakit.objects {
	/// <summary>
	/// The full details of an Asset, containing all the properties from the <see cref="AssetGeneral"/> and <see cref="AssetAdvanced"/> objects.
	/// </summary>
	/// <category>Assets</category>
	/// <override complex="true">
	/// <merge type="Vorgon.AssetGeneral" />
	/// <merge type="Vorgon.AssetAdvanced" />
	/// </override>
	public class Asset {
		/// <summary>
		/// General details about this asset.
		/// </summary>
		/// <override skip="true" />
		public AssetGeneral general { get; set; }
		/// <summary>
		/// Advanced details about this asset.
		/// </summary>
		/// <override skip="true" />
		public AssetAdvanced advanced { get; set; }
		/// <summary>
		/// Current jobs dispatched and driving directions.
		/// </summary>
		public AssetDispatch dispatch;
		/// <summary>
		/// A list of messages sent to or from this asset.
		/// </summary>
		public List<AssetMessage> messages;
		/// <summary>
		/// The current list of tasks assigned to this asset.
		/// </summary>
		/// <override skip="true" />
		public List<DispatchTask> tasks;

		/// <summary>
		/// Unique identifier of this asset.
		/// </summary>
		/// <override readonly="true" />
		public ulong id => this.general?.id
					?? this.advanced?.id
					?? this.dispatch?.id
					?? this.messages?.FirstOrDefault()?.asset
					?? this.tasks?.FirstOrDefault()?.asset
					?? 0;
		/// <summary>
		/// Object version keys used to validate synchronization for all object properties.
		/// </summary>
		/// <override name="v" count="3" readonly="true">
		/// <element key="0">The first element is for the <see cref="AssetGeneral"/> properties.</element>
		/// <element key="1">The second element is for the <see cref="AssetAdvanced"/> properties.</element>
		/// <element key="2">The third element is for the <see cref="dispatch"/> properties.</element>
		/// </override>
		public int[] version => new[] {
			(int?)this.general?.version[0] ?? -1,
			(int?)this.advanced?.version[0] ?? -1,
			(int?)this.dispatch?.version[0] ?? -1,
		};
	}

	/// <summary>
	/// The full details of a Person, containing all the properties from the <see cref="PersonGeneral"/> and <see cref="AssetAdvanced"/> objects.
	/// </summary>
	/// <category>Assets</category>
	/// <override complex="true">
	/// <merge type="Vorgon.PersonGeneral" />
	/// <merge type="Vorgon.AssetAdvanced" />
	/// </override>
	public class Person : Asset {
		/// <summary>
		/// General details about this person.
		/// </summary>
		/// <override skip="true" />
		new public PersonGeneral general {
			get => (PersonGeneral)base.general;
			set => base.general = value;
		}
	}

	/// <summary>
	/// The full details of a Trailer, containing all the properties from the <see cref="TrailerGeneral"/> and <see cref="AssetAdvanced"/> objects.
	/// </summary>
	/// <category>Assets</category>
	/// <override complex="true">
	/// <merge type="Vorgon.TrailerGeneral" />
	/// <merge type="Vorgon.AssetAdvanced" />
	/// </override>
	public class Trailer : Asset {
		/// <summary>
		/// General details about this trailer.
		/// </summary>
		/// <override skip="true" />
		new public TrailerGeneral general {
			get => (TrailerGeneral)base.general;
			set => base.general = value;
		}
	}

	/// <summary>
	/// The full details of a Vehicle, containing all the properties from the <see cref="VehicleGeneral"/> and <see cref="VehicleAdvanced"/> objects.
	/// </summary>
	/// <category>Assets</category>
	/// <override complex="true">
	/// <merge type="Vorgon.VehicleGeneral" />
	/// <merge type="Vorgon.VehicleAdvanced" />
	/// </override>
	public class Vehicle : Asset {
		/// <summary>
		/// General details about this vehicle.
		/// </summary>
		/// <override skip="true" />
		new public VehicleGeneral general {
			get => (VehicleGeneral)base.general;
			set => base.general = value;
		}
		/// <summary>
		/// Advanced details about this vehicle.
		/// </summary>
		/// <override skip="true" />
		new public VehicleAdvanced advanced {
			get => (VehicleAdvanced)base.advanced;
			set => base.advanced = value;
		}
	}
}