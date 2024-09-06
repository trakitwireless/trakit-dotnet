namespace trakit.objects {
	/// <summary>
	/// A <see cref="Timezone"/> selection control.
	/// </summary>
	/// <category>File Hosting</category>
	public class FormFieldTimezone : FormFieldBase {
		/// <summary>
		/// Just <see cref="FormFieldType.timezone"/> control type.
		/// </summary>
		protected override FormFieldType[] supported => new[] {
			FormFieldType.timezone,
		};
	}
}