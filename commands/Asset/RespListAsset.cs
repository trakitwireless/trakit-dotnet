using System.Collections.Generic;
using trakit.objects;

namespace trakit.commands {
	/// <summary>
	/// A container for the requested <see cref="assets"/>.
	/// </summary>
	public abstract class RespListAsset : Response {
		/// <summary>
		/// The list of requested <see cref="Asset"/>s.
		/// </summary>
		public Asset[] assets;
	}

	/// <summary>
	/// Contains the <see cref="Company.id"/> of the collection.
	/// </summary>
	public class RespListAssetByCompany : RespListAsset {
		/// <summary>
		/// Identifier of the <see cref="Company"/> to which this collection belongs.
		/// </summary>
		public RespId company;
	}
	/// <summary>
	/// A container owner <see cref="Company"/> of the collection.
	/// </summary>
	public class RespListAssetByCompanyAndLabels : RespListAssetByCompany {
		/// <summary>
		/// The parsed labels given as input.
		/// </summary>
		/// <seealso cref="AssetGeneral.labels"/>
		public string[] labels;
	}
	/// <summary>
	/// A container owner <see cref="Company"/> of the collection.
	/// </summary>
	public class RespListAssetByCompanyAndRefPairs : RespListAssetByCompany {
		/// <summary>
		/// The parsed references given as input.
		/// </summary>
		/// <seealso cref="AssetGeneral.references"/>
		public Dictionary<string, string> references;
	}
}