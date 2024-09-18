using System;
using System.Collections.Generic;

namespace trakit.objects {
	/// <summary>
	/// An interface for objects that have "labels".
	/// </summary>
	/// <seealso cref="CompanyStyles.labels" />
	public interface ILabelled {
		/// <summary>
		/// A list of codified labels for this asset or place.
		/// </summary>
		List<string> labels { get; }
	}
}