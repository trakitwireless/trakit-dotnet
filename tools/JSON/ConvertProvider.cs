using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using trakit.objects;

namespace trakit.tools {
	/// <summary>
	/// 
	/// </summary>
	public class ConvertProvider : TrakitConverter<Provider> {
		public ConvertProvider(Serializer owner) : base(owner) { }

		public override Provider ReadJson(JsonReader reader, Type type, Provider provider, bool existing, JsonSerializer serializer) {
			var obj = JObject.Load(reader);
			provider = new Provider() {
				general = obj.ToObject<ProviderGeneral>(this.owner.newton),
				advanced = obj.ToObject<ProviderAdvanced>(this.owner.newton),
				control = obj.ToObject<ProviderControl>(this.owner.newton),
			};
			provider.v = obj["v"].Select(p => (int)p).ToArray();
			return provider;
		}
		public override void WriteJson(JsonWriter writer, Provider provider, JsonSerializer serializer) {
			var obj = new JObject(
				new JProperty("id", provider.id),
				new JProperty("company", provider.company),
				new JProperty("v", provider.v)
			);

			// general
			if (provider.general != null) {
				foreach (var prop in JObject.FromObject(provider.general, serializer).Properties().Where(p => _valid(p))) {
					obj.Add(prop);
				}
			}
			// advanced
			if (provider.advanced != null) {
				foreach (var prop in JObject.FromObject(provider.advanced, serializer).Properties().Where(p => _valid(p))) {
					obj.Add(prop);
				}
			}
			// advanced
			if (provider.control != null) {
				foreach (var prop in JObject.FromObject(provider.control, serializer).Properties().Where(p => _valid(p))) {
					obj.Add(prop);
				}
			}

			obj.WriteTo(writer);
		}
	}
}