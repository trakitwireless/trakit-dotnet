using System.Net.Http;
using Newtonsoft.Json;

namespace trakit.commands {
	/// <summary>
	/// Base class for all command parameters.
	/// All command parameter classes use this as the base.
	/// </summary>
	/// <remarks>
	/// This class exists solely to create an inheritance chain.
	/// Child classes should contain members required to execute a command.
	/// </remarks>
	public abstract class Request {
		/// <summary>
		/// Identifier used by external system to correlate requests to responses.
		/// </summary>
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public int? reqId { get; set; }

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[JsonIgnore]
		public abstract HttpMethod httpVerb { get; }
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[JsonIgnore]
		public abstract string httpRoute { get; }
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		[JsonIgnore]
		public abstract string socketCommand { get; }
	}
}