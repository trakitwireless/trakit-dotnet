using System;
using Newtonsoft.Json;
using trakit.objects;

namespace trakit.tools {
	/// <summary>
	/// 
	/// </summary>
	public class ConvertPlace : TrakitConverter<Place> {
		public override Place ReadJson(JsonReader reader, Type objectType, Place existingValue, bool hasExistingValue, JsonSerializer serializer) => throw new NotImplementedException();
		public override void WriteJson(JsonWriter writer, Place value, JsonSerializer serializer) => throw new NotImplementedException();
	}
}