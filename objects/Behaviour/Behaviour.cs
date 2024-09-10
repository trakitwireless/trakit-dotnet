using System.Collections.Generic;

namespace trakit.objects {
	/// <summary>
	/// The applied behaviour which includes all parameters and targets specific assets.
	/// </summary>
	/// <category>Behaviours</category>
	public class Behaviour : Subscribable, IIdUlong, INamed, IBelongCompany {
		/// <summary>
		/// Unique identifier of this behaviour.
		/// </summary>
		public ulong id { get; set; }
		/// <summary>
		/// The company to which this behaviour belongs.
		/// </summary>
		/// <seealso cref="Company.id" />
		public ulong company { get; set; }
		/// <summary>
		/// The script which this behaviour implements.
		/// </summary>
		/// <seealso cref="BehaviourScript.id" />
		public ulong script { get; set; }
		/// <summary>
		/// The name of this behaviour.
		/// </summary>
		/// <override max-length="100" />
		public string name { get; set; }
		/// <summary>
		/// Notes.
		/// </summary>
		public string notes { get; set; }
		/// <summary>
		/// The priority flag allows you to define an execution order for all behaviours for a provider.
		/// </summary>
		public byte priority;
		/// <summary>
		/// The search pattern used to target the assets which will embed this behaviour in their execution context.
		/// </summary>
		/// <override type="System.String" format="expression" />
		public string targets;
		/// <summary>
		/// A search pattern used to filter the providers which can implement this behaviour.
		/// </summary>
		/// <override type="System.String" format="expression" />
		public string filters;
		/// <summary>
		/// The list of defined variable name/value pairs for the script requires.
		/// </summary>
		public Dictionary<string, BehaviourParameter> parameters;
	}
}