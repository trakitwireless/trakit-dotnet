﻿using trakit.objects;

namespace trakit.commands {
	/// <summary>
	/// A container for the <see cref="contact"/> object.
	/// </summary>
	public abstract class ReqContact : IReqSingle {
		/// <summary>
		/// An object to contain the "id" of the <see cref="Contact"/>.
		/// </summary>
		public ParamId contact { get; set; }

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public string getKey() => this.contact?.id.ToString() ?? "";
	}
}