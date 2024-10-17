﻿using Newtonsoft.Json;

namespace trakit.commands {
	/// <summary>
	/// Base class for all responses from commands.
	/// All command response classes use this as the base.
	/// </summary>
	/// <remarks>
	/// It will always have the <see cref="reqId"/>, <see cref="errorCode"/>, <see cref="message"/>, and <see cref="errorDetails"/> properties, but can also contain any number of other properties.
	/// A child class per command type should be created.
	/// </remarks>
	public abstract class Response {
		/// <summary>
		/// Identifier used by external system to correlate requests to responses.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public int? reqId { get; set; }
		/// <summary>
		/// The unique, numeric error code when processing this request.
		/// </summary>
		public ErrorCode errorCode { get; set; }
		/// <summary>
		/// An English description of the error.
		/// </summary>
		public string message { get; set; }
		/// <summary>
		/// An object to provide developers with a hint about the nature of the error.
		/// The key is not always present, and only available for some errors.
		/// </summary>
		public ErrorDetail errorDetails { get; set; }
	}
}