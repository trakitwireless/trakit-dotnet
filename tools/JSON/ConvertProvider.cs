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
		public override bool CanWrite => false;
		public ConvertProvider(Serializer owner) : base(owner) { }

		public override Provider deconvert(JsonReader reader, Type type, Provider provider, bool existing, JsonSerializer serializer) {
			var obj = JObject.Load(reader);
			provider = new Provider() {
				general = obj.ToObject<ProviderGeneral>(this.owner.newton),
				advanced = obj.ToObject<ProviderAdvanced>(this.owner.newton),
				control = obj.ToObject<ProviderControl>(this.owner.newton),
			};
			provider.v = obj["v"].Select(p => (int)p).ToArray();
			return provider;
		}
		public override void convert(JsonWriter writer, Provider value, JsonSerializer serializer) => throw new NotImplementedException();
	}
}