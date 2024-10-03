using System;

namespace trakit.objects {
	/// <summary>
	/// The full details of a Trailer, containing all the properties from the <see cref="TrailerGeneral"/> and <see cref="AssetAdvanced"/> objects.
	/// </summary>
	public class Trailer : Asset {
		/// <summary>
		/// General details about this trailer.
		/// </summary>
		new public TrailerGeneral general {
			get => (TrailerGeneral)base.general;
			set => base.general = value;
		}

		/// <summary>
		/// Manufacturer's unique identification number for this trailer.
		/// </summary>
		/// <override max-length="50" />
		public string vin {
			get => this.general?.serial ?? throw new NullReferenceException("general");
			set => (this.general ?? throw new NullReferenceException("general")).serial = value;
		}
		/// <summary>
		/// The license plate.
		/// </summary>
		/// <override max-length="50" />
		public string plate {
			get => this.general?.plate ?? throw new NullReferenceException("general");
			set => (this.general ?? throw new NullReferenceException("general")).plate = value;
		}
		/// <summary>
		/// Manufacturer's name.
		/// </summary>
		/// <override max-length="50" />
		public string make {
			get => this.general?.make ?? throw new NullReferenceException("general");
			set => (this.general ?? throw new NullReferenceException("general")).make = value;
		}
		/// <summary>
		/// Manufacturer's model name/number.
		/// </summary>
		/// <override max-length="50" />
		public string model {
			get => this.general?.model ?? throw new NullReferenceException("general");
			set => (this.general ?? throw new NullReferenceException("general")).model = value;
		}
		/// <summary>
		/// Year of manufacturing.
		/// </summary>
		public ushort year {
			get => this.general?.year ?? throw new NullReferenceException("general");
			set => (this.general ?? throw new NullReferenceException("general")).year = value;
		}
		/// <summary>
		/// Primary colour of the vehicle (given in 24bit hex; #RRGGBB)
		/// </summary>
		/// <override max-length="22" format="colour" />
		public string colour {
			get => this.general?.colour ?? throw new NullReferenceException("general");
			set => (this.general ?? throw new NullReferenceException("general")).colour = value;
		}
	}
}