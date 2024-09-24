using System;
using System.Collections.Generic;
using System.Text;

namespace trakit.objects {
	/// <summary>
	/// Base class for all command parameters.
	/// All command parameter classes use this as the base.
	/// </summary>
	/// <remarks>
	/// This class exists solely to create an inheritance chain.
	/// Child classes should contain members required to execute a command.
	/// </remarks>
	/// <category>API Definitions - Requests</category>
	/// <override skip="false" name="BaseParameters" />
	public abstract class ParameterType {
		/// <summary>
		/// Identifier used by external system to correlate requests to responses.
		/// </summary>
		public int? reqId { get; set; }
	}
	/// <summary>
	/// An interface that when implemented can be used with validator.byCompany.
	/// </summary>
	/// <category>Companies</category>
	public interface IParameterCompany {
		ParamId company { get; set; }
	}
	/// <summary>
	/// An interface that when implemented can be used with validator.byAsset.
	/// </summary>
	/// <category>Assets</category>
	public interface IParameterAsset {
		ParamId asset { get; set; }
	}
	/// <summary>
	/// An interface that when implemented can be used with validator.byBillingProfile.
	/// </summary>
	/// <category>Billing</category>
	public interface IParameterBillingProfile {
		ParamId billingProfile { get; set; }
	}
}
