using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using trakit.objects;

namespace trakit.tools {
	/// <summary>
	/// 
	/// </summary>
	public class ConvertUser : TrakitConverter<User> {
		public override User? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
			var obj = this.readObject(ref reader);
			return JsonSerializer.Deserialize<User>(obj, options);
		}
	}
}