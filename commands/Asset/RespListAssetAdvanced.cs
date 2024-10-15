using System.Collections.Generic;
using trakit.objects;

namespace trakit.commands {
	/// <summary>
	/// A container for the <see cref="assetAdvanceds"/> collection.
	/// </summary>
	public abstract class RespListAssetAdvanced : Response {
		/// <summary>
		/// The list of requested <see cref="AssetAdvanced"/>s.
		/// </summary>
		public AssetAdvanced[] assetAdvanceds;
	}

	/// <summary>
	/// A container owner <see cref="Company"/> of the collection.
	/// </summary>
	public class RespListAssetAdvancedByCompany : RespListAssetAdvanced {
		/// <summary>
		/// Identifier of the <see cref="Company"/> to which this collection belongs.
		/// </summary>
		public RespId company;
	}
	/// <summary>
	/// A container owner <see cref="Company"/> of the collection.
	/// </summary>
	public class RespListAssetAdvancedByCompanyAndLabels : RespListAssetAdvancedByCompany {
		/// <summary>
		/// The labels given as input.
		/// </summary>
		/// <seealso cref="AssetGeneral.labels"/>
		public string[] labels;
	}
	/// <summary>
	/// A container owner <see cref="Company"/> of the collection.
	/// </summary>
	public class RespListAssetAdvancedByCompanyAndRefPairs : RespListAssetAdvancedByCompany {
		/// <summary>
		/// The reference string given as input.
		/// </summary>
		/// <seealso cref="AssetGeneral.references"/>
		public Dictionary<string, string> references;
	}
}