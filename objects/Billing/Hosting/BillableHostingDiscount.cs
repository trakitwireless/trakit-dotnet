﻿using System;
using System.Collections.Generic;

namespace trakit.objects {
	/// <summary>
	/// A discount rule for assets
	/// </summary>
	/// <override skip="true" />
	[Obsolete("Never implemented.")]
	public class BillableHostingDiscount : BillableHostingBase {
		/// <summary>
		/// The type of services being discounted.
		/// </summary>
		public List<BillableHostingType> services;
		/// <summary>
		/// When true, the amount is used as a percentage value instead of a currency values.
		/// </summary>
		public bool percentage;
	}
}