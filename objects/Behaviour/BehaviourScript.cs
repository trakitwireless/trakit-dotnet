using System.Collections.Generic;

namespace trakit.objects {
	/// <summary>
	/// Possible data-types given to BehaviourParameters.
	/// </summary>
	public enum BehaviourParameterType : byte {
		/// <summary>
		/// True or false.
		/// </summary>
		boolean,
		/// <summary>
		/// Numeric value (signed double-precision floating point number).
		/// </summary>
		number,
		/// <summary>
		/// Text.
		/// </summary>
		@string,
		/// <summary>
		/// Object or array literal.
		/// </summary>
		json,
	}

	/// <summary>
	/// Business logic run by the system to react to GPS events and device information.
	/// </summary>
	public class BehaviourScript : Subscribable, IIdUlong, INamed, IBelongCompany, IGlobal, IVisual {
		/// <summary>
		/// Unique identifier of this script.
		/// </summary>
		public ulong id { get; set; }
		/// <summary>
		/// The company to which this script belongs.
		/// </summary>
		/// <seealso cref="Company.id" />
		public ulong company { get; set; }
		/// <summary>
		/// The nickname given to this script.
		/// </summary>
		/// <override max-length="100" />
		public string name { get; set; }
		/// <summary>
		/// Usage notes and instructions for users on how best to setup this script.
		/// </summary>
		public string notes { get; set; }
		/// <summary>
		/// Indicates whether this script is available to child companies.
		/// </summary>
		public bool global { get; set; }
		/// <summary>
		/// The source code.
		/// </summary>
		/// <override max-length="8060" />
		public string source;
		/// <summary>
		/// A list of targeting expressions.  These expressions are defaults for derived Behaviours.
		/// </summary>
		/// <override type="System.String" format="expression" />
		public string filters;
		/// <summary>
		/// Listed parameters for the Behaviour function.
		/// </summary>
		public Dictionary<string, BehaviourParameter> parameters;
		/// <summary>
		/// Flag set by the compiler if this code compiles
		/// </summary>
		public bool compiles;
		/// <summary>
		/// The background colour given to this script for easy visual identification.
		/// </summary>
		/// <override max-length="22" format="colour" />
		public string fill { get; set; }
		/// <summary>
		/// The text/graphic colour given to this script for easy visual identification.
		/// </summary>
		/// <override max-length="22" format="colour" />
		public string stroke { get; set; }
		/// <summary>
		/// The codified graphic name given to this script for easy visual identification.
		/// </summary>
		/// <override max-length="22" format="codified" />
		public string graphic { get; set; }
	}

	/// <summary>
	/// Definition of an argument passed to a Behaviour Script.
	/// </summary>
	public class BehaviourParameter {
		/// <summary>
		/// Simple type information for the compiler.
		/// </summary>
		public BehaviourParameterType type;
		/// <summary>
		/// The value is given as a string, but parsed into native type when compiled.
		/// </summary>
		public string? value;
		/// <summary>
		/// Usage notes.
		/// </summary>
		public string notes;
		/// <summary>
		/// Gives a hint to the client on the best UI to use for editing.
		/// For example, "checkbox" is a good UI hint for boolean parameter types.
		/// </summary>
		public string? context;
	}
}