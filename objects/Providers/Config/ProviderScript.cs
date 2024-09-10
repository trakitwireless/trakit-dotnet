using System.Collections.Generic;

namespace trakit.objects {
	/// <summary>
	/// Possible data-types given to ProviderScriptParameter.
	/// </summary>
	public enum ProviderScriptParameterType : byte {
		/// <summary>
		/// True or false.
		/// </summary>
		boolean,
		/// <summary>
		/// Numeric value (double-precision floating point number).
		/// </summary>
		number,
		/// <summary>
		/// Text.
		/// </summary>
		text,
	}

	/// <summary>
	/// This class describes a type of logic applied to a provider.
	/// A script will generate a file which is loaded onto a provider in the field.
	/// </summary>
	public class ProviderScript : Subscribable, IIdUlong, INamed,  IBelongCompany, IGlobal, IVisual {
		/// <summary>
		/// Unique identifier of this configuration.
		/// </summary>
		public ulong id { get; set; }
		/// <summary>
		/// The company to which this configuration belongs.
		/// </summary>
		/// <seealso cref="Company.id" />
		public ulong company { get; set; }
		/// <summary>
		/// The nickname given to this configuration
		/// </summary>
		/// <override max-length="100" />
		public string name { get; set; }
		/// <summary>
		/// Simple details about how the providers are expected to behave.
		/// </summary>
		public string notes { get; set; }

		/// <summary>
		/// The fill/background colour of the icon.
		/// </summary>
		/// <override max-length="22" format="colour" />
		public string fill { get; set; }
		/// <summary>
		/// Outline and graphic colour.
		/// </summary>
		/// <override max-length="22" format="colour" />
		public string stroke { get; set; }
		/// <summary>
		/// The name of the symbol for this script.
		/// </summary>
		/// <override max-length="22" format="codified" />
		public string graphic { get; set; }

		/// <summary>
		/// Indicates whether this script is available to child companies.
		/// </summary>
		public bool global { get; set; }
		/// <summary>
		/// The type of provider for which this script can be used.
		/// Limiting to a specific model from a manufacturer is accomplished through the block conditions.
		/// </summary>
		public ProviderType kind { get; set; }
		/// <summary>
		/// Blocks of file data which are (optionally) included in the script data file.
		/// </summary>
		public List<ProviderScriptBlock> blocks;
		/// <summary>
		/// Parameter definitions for this script, including type-hints and default values.
		/// </summary>
		public Dictionary<string, ProviderScriptParameter> parameters;
	}

	/// <summary>
	/// Definition of an argument passed to a ProviderScript.
	/// </summary>
	public class ProviderScriptParameter {
		/// <summary>
		/// Simple type information for the gateway to process.
		/// </summary>
		public ProviderScriptParameterType type;
		/// <summary>
		/// The value is given as a string, but parsed into native type when used by the gateway.
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
		/// <summary>
		/// The order in which this parameter is displayed compared to other parameters.
		/// The value has no effect on how this parameter is inserted into the ProviderScriptBlocks.
		/// </summary>
		public uint order;
		/// <summary>
		/// Used as a hint that this parameter controls an advanced script option and should only be set if you really know what you're doing.
		/// </summary>
		public bool advanced;
	}
	/// <summary>
	/// A chunk of script and variables used to assemble a working ProviderScript.
	/// </summary>
	public class ProviderScriptBlock {
		/// <summary>
		/// A chunk of the file loaded onto a provider with it's variables replaced with configurable variables.
		/// Trailing or leading whitespace should be included here, so when blocks are merged, so too is the newline characters.
		/// </summary>
		public string content;
		/// <summary>
		/// A regular expression used to match variables in the content.
		/// The regex must contain at least one match-group.
		/// The value fom the last group is what's used as a parameter name.
		/// </summary>
		/// <example>{{([a-z]+)}}</example>
		/// <example>&lt;(var[a-z]+)&gt;</example>
		/// <override max-length="20" />
		public string replace;
		/// <summary>
		/// When defined, this condition matches a <see cref="ProviderScriptParameter"/> defined in the <see cref="ProviderConfig"/> to include or exclude this chunk from the script.
		/// </summary>
		/// <override max-length="50" />
		public string? condition;
		/// <summary>
		/// Used in conjunction with condition, this value must match the given ProviderScriptParameter value to have the chunk included.
		/// </summary>
		public string? validate;
	}
}