using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using trakit.objects;

namespace trakit.tools {
	/// <summary>
	/// 
	/// </summary>
	public class ConvertAsset : TrakitConverter<Asset> {
		public override Asset? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
			return null;
		}
	}
}