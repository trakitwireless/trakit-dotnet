using System;
using Newtonsoft.Json;
using trakit.objects;

namespace trakit.tools {
	/// <summary>
	/// 
	/// </summary>
	public class ConvertUser : TrakitConverter<User> {
		public override User? ReadJson(JsonReader reader, Type objectType, User? existingValue, bool hasExistingValue, JsonSerializer serializer) => throw new NotImplementedException();
		public override void WriteJson(JsonWriter writer, User? value, JsonSerializer serializer) => throw new NotImplementedException();
	}
}