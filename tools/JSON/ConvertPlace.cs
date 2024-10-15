using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using trakit.objects;

namespace trakit.tools {
	/// <summary>
	/// 
	/// </summary>
	public class ConvertPlace : TrakitConverter<Place> {
		public ConvertPlace(Serializer owner) : base(owner) { }

		public override Place deconvert(JsonReader reader, Type type, Place place, bool existing, JsonSerializer serializer) {
			var obj = JObject.Load(reader);
			if (!Enum.TryParse(obj["kind"].ToString(), true, out PlaceType kind)) throw new JsonException();

			switch (obj["points"]?.Type) {
				case JTokenType.String:
					// overwrite object
					obj["points"] = JArray.FromObject(polyline.decode(obj["points"].ToString()));
					break;
			}
			place = obj.ToObject<Place>(this.owner.newton);
			return place;
		}
		public override void convert(JsonWriter writer, Place value, JsonSerializer serializer) => throw new NotImplementedException();
	}
}