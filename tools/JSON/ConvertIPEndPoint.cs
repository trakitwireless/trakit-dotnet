using System;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace trakit.tools {
	/// <summary>
	/// 
	/// </summary>
	public class ConvertIPEndPoint : TrakitConverter<IPEndPoint> {
		public override IPEndPoint deconvert(JsonReader reader, Type type, IPEndPoint ipEnd, bool existing, JsonSerializer serializer) {
			switch (reader.TokenType) {
				case JsonToken.StartObject:
					var obj = JObject.Load(reader);
					ipEnd = new IPEndPoint(
						obj["address"].ToObject<IPAddress>(serializer),
						obj["port"].Value<int>()
					);
					break;
				case JsonToken.String:
					string[] addressPort = reader.Value.ToString().Split(':');
					ipEnd = new IPEndPoint(
						IPAddress.Parse(addressPort[0]),
						int.Parse(addressPort[1])
					);
					break;
			}
			return ipEnd;
		}
		public override void convert(JsonWriter writer, IPEndPoint value, JsonSerializer serializer) {
			var obj = new JValue(value.ToString());
			obj.WriteTo(writer);
		}
	}
}