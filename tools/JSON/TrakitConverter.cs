using System;
using Newtonsoft.Json;
using trakit.objects;

namespace trakit.tools {
	/// <summary>
	/// 
	/// </summary>
	public abstract class TrakitConverter<T> : JsonConverter<T> where T : Subscribable {

	}
}