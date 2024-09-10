namespace trakit.objects {
	/// <summary>
	/// A context hint for the size of a measurements.
	/// </summary>
	public enum FormFieldNumericSize : byte {
		/// <summary>
		/// A small measurement.
		/// For <see cref="FormFieldType.distance"/>: <see cref="Units.CENTIMETER"/>/<see cref="Units.INCH"/>
		/// For <see cref="FormFieldType.weight"/>: <see cref="Units.GRAM"/>/<see cref="Units.OUNCE"/>
		/// For <see cref="FormFieldType.volume"/>: <see cref="Units.MILLILITER"/>/<see cref="Units.OUNCE"/>
		/// For <see cref="FormFieldType.speed"/>: <see cref="Units.CENTIMETER_PER_SECOND"/>/<see cref="Units.INCH_PER_SECOND"/>
		/// For <see cref="FormFieldType.area"/>: <see cref="Units.SQUARE_METRE"/>/<see cref="Units.SQUARE_FOOT"/>
		/// </summary>
		small,
		/// <summary>
		/// A medium measurement.
		/// For <see cref="FormFieldType.distance"/>: <see cref="Units.METER"/>/<see cref="Units.FOOT"/>
		/// For <see cref="FormFieldType.weight"/>: <see cref="Units.KILOGRAM"/>/<see cref="Units.POUND"/>
		/// For <see cref="FormFieldType.volume"/>: same as <see cref="FormFieldNumericSize.small"/>
		/// For <see cref="FormFieldType.speed"/>: <see cref="Units.METER_PER_SECOND"/>/<see cref="Units.FOOT_PER_SECOND"/>
		/// For <see cref="FormFieldType.area"/>: <see cref="Units.SQUARE_KILOMETRE"/>/<see cref="Units.SQUARE_MILE"/>
		/// </summary>
		medium,
		/// <summary>
		/// A large measurement.
		/// For <see cref="FormFieldType.distance"/>: <see cref="Units.KILOMETER"/>/<see cref="Units.MILE"/>
		/// For <see cref="FormFieldType.weight"/>: <see cref="Units.TONNE"/>/<see cref="Units.TON"/>
		/// For <see cref="FormFieldType.volume"/>: <see cref="Units.LITER"/>/<see cref="Units.GALLON"/>
		/// For <see cref="FormFieldType.speed"/>: <see cref="Units.KILOMETER_PER_HOUR"/>/<see cref="Units.MILE_PER_HOUR"/>
		/// For <see cref="FormFieldType.area"/>: <see cref="Units.HECTARE"/>/<see cref="Units.ACRE"/>
		/// </summary>
		large,
	}

	/// <summary>
	/// A numeric value input control with multiple contexts available.
	/// </summary>
	/// <remarks>
	/// For this field, the <see cref="FormFieldBase.kind"/> is just a helper for the UI, and does not affect input validation.
	/// </remarks>
	public class FormFieldNumeric : FormFieldBase {
		/// <summary>
		/// These are the numeric control types.
		/// </summary>
		protected override FormFieldType[] supported => new[] {
			FormFieldType.numeric,
			FormFieldType.range,
			FormFieldType.distance,
			FormFieldType.area,
			FormFieldType.temperature,
			FormFieldType.weight,
			FormFieldType.volume,
			FormFieldType.pressure,
			FormFieldType.speed,
			FormFieldType.fuelEconomy,
			FormFieldType.currency,
		};

		/// <summary>
		/// A context hint for the kind of numeric size for this field.
		/// Used only for <see cref="FormFieldType.distance"/>, <see cref="FormFieldType.weight"/>, <see cref="FormFieldType.volume"/>,
		/// and <see cref="FormFieldType.speed"/>.
		/// </summary>
		public FormFieldNumericSize size;
		/// <summary>
		/// Number of decimal places of accuracy are required.
		/// </summary>
		public byte precision;
		/// <summary>
		/// The numeric value increments by this amount.
		/// </summary>
		public double step;
		/// <summary>
		/// An optional suffix for this numeric value, like "%" or "ppm".
		/// This value is ignored for <see cref="FormFieldType.distance"/>, <see cref="FormFieldType.weight"/>,
		/// <see cref="FormFieldType.volume"/>, <see cref="FormFieldType.speed"/>, and <see cref="FormFieldType.area"/> field types.
		/// And for <see cref="FormFieldType.currency"/> fields it acts as a prefix, like "$" or "USD".
		/// </summary>
		public string units;
		/// <summary>
		/// The (optional) minimum value.
		/// </summary>
		public double? minimum;
		/// <summary>
		/// The (optional) maximum value.
		/// </summary>
		public double? maximum;
	}
}