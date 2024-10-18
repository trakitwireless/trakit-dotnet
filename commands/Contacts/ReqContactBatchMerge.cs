using System.Collections.Generic;
using System;
using trakit.objects;
using System.Net.Http;

namespace trakit.commands {
	/// <summary>
	/// 
	/// </summary>
	public class ReqContactBatchMerge : Request {
		/// <summary>
		/// 
		/// </summary>
		public ReqContactMerge.Content[] contacts { get; set; }
	}
}