using System;
using Newtonsoft.Json;
using trakit.objects;

namespace trakit.tools {
	/// <summary>
	/// 
	/// </summary>
	public class ConvertProvider : TrakitConverter<Provider> {
		public override Provider ReadJson(JsonReader reader, Type objectType, Provider existingValue, bool hasExistingValue, JsonSerializer serializer) => throw new NotImplementedException();
		public override void WriteJson(JsonWriter writer, Provider value, JsonSerializer serializer) => throw new NotImplementedException();
	}
}