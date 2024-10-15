using System.Collections.Generic;
using trakit.objects;

namespace trakit.commands {
	/// <summary>
	/// A container for the <see cref="assetGenerals"/> collection.
	/// </summary>
	public abstract class RespListAssetGeneral : Response {
		/// <summary>
		/// The list of requested <see cref="AssetGeneral"/>s.
		/// </summary>
		public AssetGeneral[] assetGenerals;
	}

	/// <summary>
	/// A container owner <see cref="Company"/> of the collection.
	/// </summary>
	public class RespListAssetGeneralByCompany : RespListAssetGeneral {
		/// <summary>
		/// Identifier of the <see cref="Company"/> to which this collection belongs.
		/// </summary>
		public RespId company;
	}
	/// <summary>
	/// A container owner <see cref="Company"/> of the collection.
	/// </summary>
	public class RespListAssetGeneralByCompanyAndLabels : RespListAssetGeneralByCompany {
		/// <summary>
		/// The labels given as input.
		/// </summary>
		/// <seealso cref="AssetGeneral.labels"/>
		public string[] labels;
	}
	/// <summary>
	/// A container owner <see cref="Company"/> of the collection.
	/// </summary>
	public class RespListAssetGeneralByCompanyAndRefPairs : RespListAssetGeneralByCompany {
		/// <summary>
		/// The reference string given as input.
		/// </summary>
		/// <seealso cref="AssetGeneral.references"/>
		public Dictionary<string, string> references;
	}
}