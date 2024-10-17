using System;

namespace trakit.commands {
	/// <summary>
	/// 
	/// </summary>
	public interface IReqListByDate {
		/// <summary>
		/// 
		/// </summary>
		DateTime? after { get; set; }
		/// <summary>
		/// 
		/// </summary>
		DateTime? before { get; set; }
	}
}