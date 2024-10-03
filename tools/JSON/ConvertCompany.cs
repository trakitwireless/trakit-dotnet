using System;
using Newtonsoft.Json;
using trakit.objects;

namespace trakit.tools {
	/// <summary>
	/// 
	/// </summary>
	public class ConvertCompany : TrakitConverter<Company> {
		public override Company? ReadJson(JsonReader reader, Type objectType, Company? existingValue, bool hasExistingValue, JsonSerializer serializer) => throw new NotImplementedException();
		public override void WriteJson(JsonWriter writer, Company? value, JsonSerializer serializer) => throw new NotImplementedException();
	}
}