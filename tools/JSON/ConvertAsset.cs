using System;
using Newtonsoft.Json;
using trakit.objects;

namespace trakit.tools {
	/// <summary>
	/// 
	/// </summary>
	public class ConvertAsset : TrakitConverter<Asset> {
		public override Asset? ReadJson(JsonReader reader, Type objectType, Asset? existingValue, bool hasExistingValue, JsonSerializer serializer) => throw new NotImplementedException();
		public override void WriteJson(JsonWriter writer, Asset? value, JsonSerializer serializer) => throw new NotImplementedException();
	}
}