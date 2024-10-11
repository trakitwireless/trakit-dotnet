using System;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using trakit.objects;

namespace trakit.tools {
	/// <summary>
	/// 
	/// </summary>
	public class ConvertISuspendable : TrakitConverter<ISuspendable> {
		public ConvertISuspendable(Serializer owner) : base(owner) { }
		public override bool CanRead => false;

		public override ISuspendable ReadJson(JsonReader reader, Type type, ISuspendable asset, bool existing, JsonSerializer serializer) {
			throw new NotImplementedException("IDeltable interface; cannot create objects");
		}
		public override void WriteJson(JsonWriter writer, ISuspendable value, JsonSerializer serializer) {
			if (value?.suspended ?? false) {
				var obj = new JObject(
					new JProperty("suspended", true),
					new JProperty("since", value.since ?? DateTime.MinValue)
				);

				if (value is AssetGeneral asset) {
					obj.Add(new JProperty("id", asset.id));
					obj.Add(new JProperty("name", asset.name));
					obj.Add(new JProperty("kind", asset.kind));
					obj.Add(new JProperty("icon", asset.icon));
					obj.Add(new JProperty("labels", asset.labels));
					obj.Add(new JProperty("notes", asset.notes));
				} else if (value is ProviderGeneral provider) {
					obj.Add(new JProperty("id", provider.id));
					obj.Add(new JProperty("name", provider.name));
					obj.Add(new JProperty("kind", provider.kind));
					obj.Add(new JProperty("configuration", provider.configuration));
					obj.Add(new JProperty("notes", provider.notes));
				} else {
					throw new NotImplementedException("ISuspendable not implemented for " + value.GetType().Name);
				}

				if (value is IBelongCompany companyObj) {
					obj.Add(new JProperty("company", companyObj.company));
				}

				obj.WriteTo(writer);
			} else {

			}

		}
	}
}